namespace BreweryMaster.API.Recipe.Models.Requests
{
    public class RecipeFilterRequest
    {
        public string? Name { get; set; }
        public int? TypeId { get; set; }
        public int? BeerStyleId { get; set; }
    }
}
