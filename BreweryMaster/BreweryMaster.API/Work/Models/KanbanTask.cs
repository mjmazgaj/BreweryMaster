namespace BreweryMaster.API.WorkModule.Models
{
    public class KanbanTask
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public int Status { get; set; }
        public DateTime DueDate { get; set; }
        public int OwnerId { get; set; }
        public int OrderId { get; set; }
    }
}
