using BreweryMaster.API.WorkModule.Models.Dtos;

namespace BreweryMaster.API.WorkModule.Models
{
    public class Column
    {
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public IEnumerable<KanbanTaskDto> Items { get; set; }

    }

}
