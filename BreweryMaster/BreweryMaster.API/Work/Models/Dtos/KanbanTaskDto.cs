﻿namespace BreweryMaster.API.Work.Models.Dtos
{
    public class KanbanTaskDto
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime DueDate { get; set; }
        public int OwnerId { get; set; }
        public int OrderId { get; set; }
        public string OwnerName { get; set; } = string.Empty;
    }
}