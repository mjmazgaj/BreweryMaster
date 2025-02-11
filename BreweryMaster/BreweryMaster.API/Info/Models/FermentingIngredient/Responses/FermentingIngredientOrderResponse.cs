namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientOrderResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int TypeId { get; set; }
        public required string TypeName { get; set; }
        public decimal? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public DateOnly OrderedDate { get; set; }
        public DateOnly? ExpectedDate { get; set; }
        public decimal OrderedQuantity { get; set; }
        public required string Unit { get; set; }
        public string? Info { get; set; }
    }
}
