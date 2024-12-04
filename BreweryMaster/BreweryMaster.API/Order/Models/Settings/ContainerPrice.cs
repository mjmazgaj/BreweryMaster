using BreweryMaster.API.OrderModule.Enums;

namespace BreweryMaster.API.OrderModule.Models
{
    public class ContainerPrice
    {
        public ContainerType ContainerType { get; set; }
        public decimal Capacity { get; set; }
        public decimal EstimatedPrice { get; set; }
    }
}
