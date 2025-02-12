namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientReservationResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int TypeId { get; set; }
        public required string TypeName { get; set; }
        public decimal? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public int? OrderId { get; set; }
        public string? OrderName { get; set; }
        public DateOnly ReservationDate { get; set; }
        public decimal ReservedQuantity { get; set; }
        public required string Unit { get; set; }
        public bool IsCompleted { get; set; }
        public string? Info { get; set; }
    }
}
