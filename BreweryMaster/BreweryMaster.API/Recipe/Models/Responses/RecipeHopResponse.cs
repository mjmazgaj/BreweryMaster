namespace BreweryMaster.API.Recipe.Models.Responses
{
    public class RecipeHopResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal AlphaAcids { get; set; }
        public decimal Quantity { get; set; }
        public required string Unit { get; set; }
        public string? Info { get; set; }
    }
}
