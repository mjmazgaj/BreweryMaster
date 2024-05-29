﻿namespace BreweryMaster.API.Models.Work
{
    public class KanbanTask
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime DueDate { get; set; }
        public int OwnerId { get; set; }
        public int OrderId { get; set; }
    }
}
