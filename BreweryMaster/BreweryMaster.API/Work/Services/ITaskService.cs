using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.Requests;
using BreweryMaster.API.WorkModule.Models;
using System.Security.Claims;

namespace BreweryMaster.API.WorkModule.Services
{
    public interface ITaskService
    {
        Task<Dictionary<string, KanbanTaskGroupResponse>> GetKanbanTasks(KanbanTaskFilterRequest? request);
        Task<KanbanTaskResponse?> GetKanbanTaskByIdAsync(int id);
        Task<KanbanTaskResponse?> CreateKanbanTaskAsync(KanbanTaskRequest kanbanTask, ClaimsPrincipal? user);
        Task<IEnumerable<KanbanTaskResponse>?> CreateKanbanTaskTemplates(KanbanTaskTemplateRequest request, ClaimsPrincipal? user);
        Task<bool> EditKanbanTaskAsync(int id, KanbanTaskUpdateRequest kanbanTask);
        Task<bool> EditKanbanTaskStatusAsync(List<KanbanTaskStatusRequest> request);
        Task<bool> DeleteKanbanTaskByIdAsync(int id);
    }
}
