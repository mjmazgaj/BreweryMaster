using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Recipe.Models.DB
{
    public class RecipeHop
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        public int HopUnitId { get; set; }
        public required HopUnit HopUnit { get; set; }
        public float Quantity { get; set; }
        public string? Info { get; set; }
    }
}
