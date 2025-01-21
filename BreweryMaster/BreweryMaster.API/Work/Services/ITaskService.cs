using BreweryMaster.API.Work.Models;
using BreweryMaster.API.WorkModule.Models;
using System.Security.Claims;

namespace BreweryMaster.API.WorkModule.Services
{
    public interface ITaskService
    {
        Task<Dictionary<string, KanbanTaskGroupResponse>> GetKanbanTasksByOwnerIdAsync(string ownerId);
        Task<IEnumerable<KanbanTaskResponse>> GetKanbanTasksByOrderIdAsync(int orderId);
        Task<KanbanTaskResponse?> GetKanbanTaskByIdAsync(int id);
        Task<KanbanTaskResponse> CreateKanbanTaskAsync(KanbanTaskRequest kanbanTask, ClaimsPrincipal? user);
        Task<bool> EditKanbanTaskAsync(int id, KanbanTaskUpdateRequest kanbanTask);
        Task<bool> EditKanbanTaskStatusAsync(List<KanbanTaskStatusRequest> request);
        Task<bool> DeleteKanbanTaskByIdAsync(int id);
    }
}
