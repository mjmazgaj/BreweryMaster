using BreweryMaster.API.Configuration.Models;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Services;
using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.DB;
using BreweryMaster.API.Work.Models.Requests;
using BreweryMaster.API.WorkModule.Mappers;
using BreweryMaster.API.WorkModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace BreweryMaster.API.WorkModule.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IOptions<WorkSettings> _options;

        public TaskService(ApplicationDbContext context, IUserService userService, IOptions<WorkSettings> options)
        {
            _context = context;
            _userService = userService;
            _options = options;
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

        public async Task<KanbanTaskResponse?> GetKanbanTaskByIdAsync(int id)
        {
            var tasks = await _context.KanbanTasks
                            .Include(x => x.Status)
                            .Include(x => x.CreatedBy)
                            .ToListAsync();

            return tasks.Select(x => x.ToResponseModel()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<KanbanTaskResponse?> CreateKanbanTaskAsync(KanbanTaskRequest kanbanTask, ClaimsPrincipal? user)
        {
            var kanbanTaskToAdd = kanbanTask.ToDbModel();
            var currentUser = await _userService.GetCurrentUser(user);

            if (currentUser is null)
                return null;

            kanbanTaskToAdd.CreatedById = currentUser.Id;
            kanbanTaskToAdd.CreatedOn = DateTime.Now;
            kanbanTaskToAdd.StatusId = 1;

            _context.KanbanTasks.Add(kanbanTaskToAdd);
            await _context.SaveChangesAsync();

            return new KanbanTaskResponse()
            {
                CreatedById = currentUser.Id,
                StatusId = kanbanTaskToAdd.StatusId,
                Status = null!,
                Title = kanbanTaskToAdd.Title,
                CreatedBy = currentUser.Email ?? "",
                CreatedOn = kanbanTaskToAdd.CreatedOn,
                DueDate = kanbanTaskToAdd.DueDate,
                Id = kanbanTaskToAdd.Id,
                Summary = kanbanTaskToAdd.Summary
            };
        }

        public async Task<IEnumerable<KanbanTaskResponse>?> CreateKanbanTaskTemplates(KanbanTaskTemplateRequest request, ClaimsPrincipal? user)
        {
            var currentUser = await _userService.GetCurrentUser(user);

            if (currentUser is null)
                return null;

            var createdTasks = new List<KanbanTaskResponse>();
            var tasks = _options.Value.TaskTemplates?.FirstOrDefault(x => x.Key == request.OrderStatus).Value;

            if (tasks is null)
                return createdTasks;

            foreach (var task in tasks)
            {
                var kanbanTaskToAdd = new KanbanTask()
                {
                    Title = task.Title,
                    Summary = task.Summary,
                    DueDate = DateTime.Now.AddDays(task.TimeDelay),
                    StatusId = 1,
                    Status = null!,
                    CreatedById = currentUser.Id,
                    CreatedBy = null!,
                    CreatedOn = DateTime.Now,
                    OrderId = request.OrderId
                };

                _context.KanbanTasks.Add(kanbanTaskToAdd);

                var createdTask = new KanbanTaskResponse()
                {
                    CreatedById = currentUser.Id,
                    StatusId = kanbanTaskToAdd.StatusId,
                    Status = null!,
                    Title = kanbanTaskToAdd.Title,
                    CreatedBy = currentUser.Email ?? "",
                    CreatedOn = kanbanTaskToAdd.CreatedOn,
                    DueDate = kanbanTaskToAdd.DueDate,
                    Id = kanbanTaskToAdd.Id,
                    Summary = kanbanTaskToAdd.Summary
                };

                createdTasks.Add(createdTask);
            }

            await _context.SaveChangesAsync();

            return createdTasks;
        }

        public async Task<bool> EditKanbanTaskAsync(int id, KanbanTaskUpdateRequest request)
        {
            if (id != request.Id)
                return false;

            var task = await _context.KanbanTasks.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (task == null)
                return false;

            task.Title = request.Title;
            task.Summary = request.Summary;
            task.DueDate = request.DueDate;
            task.AssignedToId = request.AssignTo;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditKanbanTaskStatusAsync(List<KanbanTaskStatusRequest> request)
        {
            foreach (var item in request)
            {
                var task = await _context.KanbanTasks.FirstOrDefaultAsync(x => x.Id == item.Id);

                if (task == null)
                    return false;

                task.StatusId = item.Status;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteKanbanTaskByIdAsync(int id)
        {
            var task = await _context.KanbanTasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
                return false;

            task.IsRemoved = true;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
