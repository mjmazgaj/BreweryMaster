using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreweryMaster.API.Work.Services
{
    public interface ITaskService
    {
        Task<Dictionary<string, Column>> GetKanbanTasksByOwnerIdAsync(int ownerId);
        Task<IEnumerable<KanbanTask>> GetKanbanTasksByOrderIdAsync(int orderId);
        Task<KanbanTask> GetKanbanTaskByIdAsync(int id);
        Task<KanbanTask> CreateKanbanTaskAsync(KanbanTask kanbanTask);
        Task<bool> EditKanbanTaskAsync(int id, KanbanTask kanbanTask);
        Task<bool> EditKanbanTaskStatusAsync(List<KanbanTaskStatusSaveRequest> request);
        Task<bool> DeleteKanbanTaskByIdAsync(int id);
    }
}
