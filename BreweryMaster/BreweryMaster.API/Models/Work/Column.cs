﻿namespace BreweryMaster.API.Models.Work
{
    public class Column
    {
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public IEnumerable<KanbanTaskDto> Items { get; set; }

    }

}
