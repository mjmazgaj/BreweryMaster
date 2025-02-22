using BreweryMaster.API.Work.Models;

namespace BreweryMaster.API.WorkModule.Models
{
    public class KanbanTaskGroupResponse
    {
        public required string Title { get; set; }
        public int Status { get; set; }
        public IEnumerable<KanbanTaskResponse>? Items { get; set; }
    }

}
