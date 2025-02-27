namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientReservationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public decimal? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public int? OrderId { get; set; }
        public string? OrderName { get; set; }
        public DateOnly ReservationDate { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public string? Info { get; set; }
    }
}
