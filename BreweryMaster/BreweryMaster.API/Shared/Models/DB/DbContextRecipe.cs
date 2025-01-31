using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Recipe.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        public DbSet<BeerStyleEntity> BeerStyles { get; set; }
        public DbSet<Recipe.Models.DB.Recipe> Recipes { get; set; }
        public DbSet<RecipeFermentingIngredient> RecipeFermentingIngredients { get; set; }
        public DbSet<RecipeTypeEntity> RecipeTypes { get; set; }

    }
}
