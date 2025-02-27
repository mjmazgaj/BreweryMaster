namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientOrderResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public decimal? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public DateOnly OrderedDate { get; set; }
        public DateOnly? ExpectedDate { get; set; }
        public decimal OrderedQuantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public string? Info { get; set; }
    }
}
