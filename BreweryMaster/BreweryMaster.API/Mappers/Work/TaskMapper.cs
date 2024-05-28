using BreweryMaster.API.Models.Work;

namespace BreweryMaster.API.Mappers
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
                DueDate = KanbanTaskDto.DueDate,
                OwnerId = KanbanTaskDto.OwnerId,
                OrderId = KanbanTaskDto.OrderId
            };
        }
    }
}
