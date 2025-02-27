namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientResponse
    {
        public int Id { get; set; }
        public string? TypeName { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public string? Info { get; set; }
    }
}
