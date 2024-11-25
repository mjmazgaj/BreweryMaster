using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.Dtos;

namespace BreweryMaster.API.Work.Mappers
{
    public static class KanbanTaskMapper
    {
        public static KanbanTaskDto ToDto(KanbanTask KanbanTask, string ownerName)
        {
            return new KanbanTaskDto
            {
                ID = KanbanTask.ID,
                Title = KanbanTask.Title,
                Summary = KanbanTask.Summary,
                Status = KanbanTask.Status,
                DueDate = KanbanTask.DueDate,
                OwnerId = KanbanTask.OwnerId,
                OrderId = KanbanTask.OrderId,
                OwnerName = ownerName
            };
        }

        public static KanbanTask ToDomain(KanbanTaskDto KanbanTaskDto)
        {
            return new KanbanTask
            {
                ID = KanbanTaskDto.ID,
                Title = KanbanTaskDto.Title,
                Summary = KanbanTaskDto.Summary,
                Status = KanbanTaskDto.Status,
                DueDate = KanbanTaskDto.DueDate,
                OwnerId = KanbanTaskDto.OwnerId,
                OrderId = KanbanTaskDto.OrderId
            };
        }
    }
}
