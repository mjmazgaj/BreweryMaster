using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    public class EntityPriceResponse : EntityResponse
    {
        [Precision(8, 2)]
        public decimal Price { get; set; }
    }
}
