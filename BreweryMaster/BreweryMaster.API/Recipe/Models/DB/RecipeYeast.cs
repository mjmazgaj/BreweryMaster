using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Recipe.Models.DB
{
    public class RecipeYeast
    {
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        public int YeastUnitId { get; set; }
        public required YeastUnit YeastUnit { get; set; }
        [Precision(5, 2)]
        public decimal Quantity { get; set; }
        public string? Info { get; set; }
    }
}
