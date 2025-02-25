namespace BreweryMaster.API.WorkModule.Models
{
    public class KanbanTaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string? Summary { get; set; }
        public string Status { get; set; } = String.Empty;
        public int StatusId { get; set; }
        public DateTime DueDate { get; set; }
        public string CreatedById { get; set; } = String.Empty;
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime CreatedOn { get; set; }
        public string? AssignedToId { get; set; }
        public string? AssignedTo { get; set; }
        public int? OrderId { get; set; }
        public string? Order { get; set; }
    }
}
