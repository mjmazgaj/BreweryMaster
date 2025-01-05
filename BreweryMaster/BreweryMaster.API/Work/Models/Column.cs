using BreweryMaster.API.WorkModule.Models.Dtos;

namespace BreweryMaster.API.WorkModule.Models
{
    public class Column
    {
        public required string Title { get; set; }
        public int Status { get; set; }
        public IEnumerable<KanbanTaskDto>? Items { get; set; }
    }

}
