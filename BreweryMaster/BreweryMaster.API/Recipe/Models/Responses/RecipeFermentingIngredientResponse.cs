namespace BreweryMaster.API.Info.Models
{
    public class RecipeFermentingIngredientResponse
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string? Info { get; set; }
    }
}
