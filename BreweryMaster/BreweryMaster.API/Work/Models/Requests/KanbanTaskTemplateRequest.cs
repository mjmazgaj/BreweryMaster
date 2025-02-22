using BreweryMaster.API.Configuration.Enums;

namespace BreweryMaster.API.Work.Models.Requests
{
    public class KanbanTaskTemplateRequest
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
