using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Recipe.Models.DB
{
    public class RecipeYeast
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        public int YeastUnitId { get; set; }
        public required YeastUnit YeastUnit { get; set; }
        public float Quantity { get; set; }
        public string? Info { get; set; }
    }
}
