using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.DB;
using BreweryMaster.API.WorkModule.Mappers;
using BreweryMaster.API.WorkModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.WorkModule.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, KanbanTaskGroupResponse>> GetKanbanTasksByOwnerIdAsync(string ownerId)
        {
            return await _context.KanbanTasks.Include(x => x.Status)
                .Where(x => x.AssignedToId == ownerId)
                .GroupBy(x => x.Status)
                .ToDictionaryAsync(x => x.Key.Name, x => new KanbanTaskGroupResponse()
                {
                    Title = $"Status {x.Key.Name}",
                    Status = x.Key.Id,
                    Items = x.ToList().Select(y => y.ToResponseModel())
                });
        }

        public async Task<IEnumerable<KanbanTaskResponse>> GetKanbanTasksByOrderIdAsync(int orderId)
        {
            return await _context.KanbanTasks.Where(x => x.OrderId == orderId).Select(x => x.ToResponseModel()).ToListAsync();
        }

        public async Task<KanbanTaskResponse?> GetKanbanTaskByIdAsync(int id)
        {
            return await _context.KanbanTasks.Select(x => x.ToResponseModel()).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<KanbanTask> CreateKanbanTaskAsync(KanbanTaskRequest kanbanTask)
        {
            var kanbanTaskToAdd = kanbanTask.ToDBModel();

            _context.KanbanTasks.Add(kanbanTaskToAdd);
            await _context.SaveChangesAsync();
            return kanbanTaskToAdd;
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
