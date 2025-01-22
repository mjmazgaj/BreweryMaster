using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models.Item
{
    public class ContainerPrice
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public required Container Container { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
