using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models.DB.Yeast
{
    public class YeastStored : YeastQuantity
    {
        [Precision(5, 2)]
        public decimal StoredQuantity { get; set; }
    }
}
