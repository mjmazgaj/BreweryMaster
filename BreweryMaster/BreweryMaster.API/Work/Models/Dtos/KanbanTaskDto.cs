namespace BreweryMaster.API.WorkModule.Models.Dtos
{
    public class KanbanTaskDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Summary { get; set; }
        public int Status { get; set; }
        public DateTime DueDate { get; set; }
        public int OwnerId { get; set; }
        public int OrderId { get; set; }
        public required string OwnerName { get; set; }
    }
}
