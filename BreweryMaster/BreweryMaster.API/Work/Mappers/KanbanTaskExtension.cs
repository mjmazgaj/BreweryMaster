﻿using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.DB;
using BreweryMaster.API.WorkModule.Models;

namespace BreweryMaster.API.WorkModule.Mappers
{
    public static class KanbanTaskExtension
    {
        public static KanbanTaskResponse ToResponseModel(this KanbanTask kanbanTask)
        {
            return new KanbanTaskResponse
            {
                Id = kanbanTask.Id,
                Title = kanbanTask.Title,
                Summary = kanbanTask.Summary,
                StatusId = kanbanTask.Status.Id,
                Status = kanbanTask.Status.Name,
                DueDate = kanbanTask.DueDate,
                AssignedToId = kanbanTask.AssignedToId,
                CreatedById = kanbanTask.CreatedById,
                CreatedOn = kanbanTask.CreatedOn,
                OrderId = kanbanTask.OrderId,
            };
        }

        public static KanbanTask ToDbModel(this KanbanTaskRequest kanbanTask)
        {
            return new KanbanTask
            {
                Title = kanbanTask.Title,
                Summary = kanbanTask.Summary,
                StatusId = kanbanTask.StatusId,
                Status = null!,
                DueDate = kanbanTask.DueDate,
                CreatedById = string.Empty,
                CreatedBy = null!,
                AssignedTo = null,
                AssignedToId = kanbanTask.AssignedToId,
                Order = null!,
                OrderId = kanbanTask.OrderId,
            };
        }
    }
}
