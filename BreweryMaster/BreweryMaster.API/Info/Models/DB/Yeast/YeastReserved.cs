using BreweryMaster.API.OrderModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models.DB.Yeast
{
    public class YeastReserved : YeastQuantity
    {
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        [Precision(5, 2)]
        public decimal ReservedQuantity { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
