namespace BreweryMaster.API.WorkModule.Models
{
    public class KanbanTaskResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public required string Status { get; set; }
        public int StatusId { get; set; }
        public DateTime DueDate { get; set; }
        public required string CreatedById { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? AssignedToId { get; set; }
        public string? AssignedTo { get; set; }
        public int? OrderId { get; set; }
        public string? Order { get; set; }
    }
}
