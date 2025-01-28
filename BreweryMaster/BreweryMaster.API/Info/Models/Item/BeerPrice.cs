using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models.Item
{
    public class BeerPrice
    {
        public int Id { get; set; }
        public int BeerStyleId { get; set; }
        public required BeerStyleEntity BeerStyle { get; set; }
        /// <summary>
        /// The price per 100 litters
        /// </summary>
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
