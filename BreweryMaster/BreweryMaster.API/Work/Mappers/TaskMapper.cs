using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.API.WorkModule.Models.Dtos;

namespace BreweryMaster.API.WorkModule.Mappers
{
    public static class KanbanTaskMapper
    {
        public static KanbanTaskDto ToDto(KanbanTask KanbanTask, string ownerName)
        {
            return new KanbanTaskDto
            {
                Id = KanbanTask.Id,
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
                Id = KanbanTaskDto.Id,
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
