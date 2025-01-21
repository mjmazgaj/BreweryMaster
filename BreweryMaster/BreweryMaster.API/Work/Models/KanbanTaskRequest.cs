namespace BreweryMaster.API.Work.Models
{
    public class KanbanTaskRequest
    {
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public int StatusId { get; set; }
        public DateTime DueDate { get; set; }
        public string? AssignedToId { get; set; }
        public int? OrderId { get; set; }
    }
}
