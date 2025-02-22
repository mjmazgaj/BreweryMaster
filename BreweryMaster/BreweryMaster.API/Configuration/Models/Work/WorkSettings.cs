using BreweryMaster.API.Configuration.Enums;
namespace BreweryMaster.API.Configuration.Models
{
    public class WorkSettings
    {
        public Dictionary<OrderStatus, IEnumerable<TaskTemplate>>? TaskTemplates { get; set; }
    }
}
