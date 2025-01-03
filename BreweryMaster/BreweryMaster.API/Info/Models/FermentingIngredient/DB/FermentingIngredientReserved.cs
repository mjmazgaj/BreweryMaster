using BreweryMaster.API.Shared.Enums;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientReserved
    {
        public int Id { get; set; }
        public int FermentingIngredientUnitId { get; set; }
        public float ReservedQuantity { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsRemoved { get; set; } = false;
        public string Info { get; set; }
    }
}
