using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models.DB.Yeast
{
    public class YeastOrdered : YeastQuantity
    {
        [Precision(10, 3)]
        public decimal OrderedQuantity { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime? ExpectedDate { get; set; }
    }
}
