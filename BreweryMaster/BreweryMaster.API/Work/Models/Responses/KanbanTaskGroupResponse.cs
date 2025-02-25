namespace BreweryMaster.API.WorkModule.Models
{
    public class KanbanTaskGroupResponse
    {
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public IEnumerable<KanbanTaskResponse>? Items { get; set; }
    }

}
