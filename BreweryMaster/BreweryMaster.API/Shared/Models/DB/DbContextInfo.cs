using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        public DbSet<FermentingIngredient> FermentingIngredients { get; set; }
        public DbSet<FermentingIngredientTypeEntity> FermentingIngredientTypes { get; set; }
        public DbSet<FermentingIngredientUnit> FermentingIngredientUnits { get; set; }
        public DbSet<FermentingIngredientOrdered> FermentingIngredientsOrdered { get; set; }
        public DbSet<FermentingIngredientStored> FermentingIngredientsStored { get; set; }
        public DbSet<FermentingIngredientReserved> FermentingIngredientsReserved { get; set; }

        public DbSet<Container> Containers { get; set; }
        public DbSet<ContainerPrice> ContainerPrices { get; set; }
        public DbSet<BeerPrice> BeerPrices { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }

    }
}
