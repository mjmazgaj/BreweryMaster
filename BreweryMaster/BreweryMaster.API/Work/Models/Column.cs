using BreweryMaster.API.Work.Models.Dtos;

namespace BreweryMaster.API.Work.Models
{
    public class Column
    {
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public IEnumerable<KanbanTaskDto> Items { get; set; }

    }

}
