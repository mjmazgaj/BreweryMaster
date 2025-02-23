using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models
{
    public class EntityPriceResponse : EntityResponse
    {
        [Precision(8, 2)]
        public decimal Price { get; set; }
    }
}
