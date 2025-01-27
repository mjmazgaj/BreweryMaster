using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Services;
using BreweryMaster.API.Work.Models;
using BreweryMaster.API.WorkModule.Mappers;
using BreweryMaster.API.WorkModule.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BreweryMaster.API.WorkModule.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public TaskService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<Dictionary<string, KanbanTaskGroupResponse>> GetKanbanTasksByOwnerIdAsync(ClaimsPrincipal? user)
        {
            var currentUser = await _userService.GetCurrentUser(user);

            if (currentUser is null)
                throw new Exception();

            var allStatuses = await _context.TaskStatusEntities.ToListAsync();

            var result = allStatuses.ToDictionary(
                           status => status.Name,
                           status => new KanbanTaskGroupResponse
                           {
                               Title = $"Status {status.Name}",
                               Status = status.Id,
                               Items = new List<KanbanTaskResponse>()
                           });

            var groupedTasks = await _context.KanbanTasks
                .Include(x => x.Status)
                .Where(x => x.AssignedToId == currentUser.Id)
                .GroupBy(x => x.Status)
                .ToListAsync();

            foreach (var group in groupedTasks)
            {
                if (result.ContainsKey(group.Key.Name))
                {
                    result[group.Key.Name] = new KanbanTaskGroupResponse
                    {
                        Title = $"Status {group.Key.Name}",
                        Status = group.Key.Id,
                        Items = group.Select(task => task.ToResponseModel()).ToList()
                    };
                }
            }

            return result;
        }

        public async Task<IEnumerable<KanbanTaskResponse>> GetKanbanTasksByOrderIdAsync(int orderId)
        {
            var tasks = await _context.KanbanTasks.Include(x => x.Status).ToListAsync();

            return tasks.Where(x => x.OrderId == orderId).Select(x => x.ToResponseModel());
        }

        public async Task<KanbanTaskResponse?> GetKanbanTaskByIdAsync(int id)
        {
            var tasks = await _context.KanbanTasks.Include(x => x.Status).ToListAsync();

            return tasks.Select(x => x.ToResponseModel()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<KanbanTaskResponse> CreateKanbanTaskAsync(KanbanTaskRequest kanbanTask, ClaimsPrincipal? user)
        {
            var kanbanTaskToAdd = kanbanTask.ToDbModel();
            var currentUser = await _userService.GetCurrentUser(user);

            if (currentUser is null)
                throw new Exception();

            kanbanTaskToAdd.CreatedById = currentUser.Id;
            kanbanTaskToAdd.CreatedOn = DateTime.Now;

            _context.KanbanTasks.Add(kanbanTaskToAdd);
            await _context.SaveChangesAsync();

            return new KanbanTaskResponse()
            {
                CreatedById = currentUser.Id,
                StatusId = kanbanTaskToAdd.StatusId,
                Status = null!,
                Title = kanbanTaskToAdd.Title
            };
        }

        public async Task<bool> EditKanbanTaskAsync(int id, KanbanTaskUpdateRequest kanbanTask)
        {
            if (id != kanbanTask.Id)
                return false;

            _context.Entry(kanbanTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KanbanTaskExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> EditKanbanTaskStatusAsync(List<KanbanTaskStatusRequest> request)
        {
            foreach (var item in request)
            {
                var task = await _context.KanbanTasks.FirstOrDefaultAsync(x => x.Id == item.Id);

                if (task != null)
                    task.StatusId = item.Status;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return true;
        }

        public async Task<bool> DeleteKanbanTaskByIdAsync(int id)
        {
            var kanbanTask = await _context.KanbanTasks.FirstOrDefaultAsync(x => x.Id == id);

            if (kanbanTask == null)
                return false;

            _context.KanbanTasks.Remove(kanbanTask);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool KanbanTaskExists(int id)
        {
            return _context.KanbanTasks.Any(x => x.Id == id);
        }
    }
}
