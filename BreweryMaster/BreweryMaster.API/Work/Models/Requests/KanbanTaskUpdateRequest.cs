namespace BreweryMaster.API.Work.Models
{
    public class KanbanTaskUpdateRequest : KanbanTaskRequest
    {
        public int Id { get; set; }
        public string? AssignTo { get; set; }
    }
}
