using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.DB;
using BreweryMaster.API.WorkModule.Models;

namespace BreweryMaster.API.WorkModule.Services
{
    public interface ITaskService
    {
        Task<Dictionary<string, KanbanTaskGroupResponse>> GetKanbanTasksByOwnerIdAsync(string ownerId);
        Task<IEnumerable<KanbanTaskResponse>> GetKanbanTasksByOrderIdAsync(int orderId);
        Task<KanbanTaskResponse?> GetKanbanTaskByIdAsync(int id);
        Task<KanbanTask> CreateKanbanTaskAsync(KanbanTaskRequest kanbanTask);
        Task<bool> EditKanbanTaskAsync(int id, KanbanTaskUpdateRequest kanbanTask);
        Task<bool> EditKanbanTaskStatusAsync(List<KanbanTaskStatusRequest> request);
        Task<bool> DeleteKanbanTaskByIdAsync(int id);
    }
}
