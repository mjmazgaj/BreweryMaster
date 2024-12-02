using BreweryMaster.API.Order.Models.ProspectOrder;

namespace BreweryMaster.API.Order.Models.Settings
{
    public class ContainerPrice
    {
        public ContainerType ContainerType { get; set; }
        public decimal Capacity { get; set; }
        public decimal EstimatedPrice { get; set; }
    }
}
