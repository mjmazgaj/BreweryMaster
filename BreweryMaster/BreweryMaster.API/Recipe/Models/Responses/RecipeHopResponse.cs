namespace BreweryMaster.API.Recipe.Models.Responses
{
    public class RecipeHopResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal AlphaAcids { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string? Info { get; set; }
    }
}
