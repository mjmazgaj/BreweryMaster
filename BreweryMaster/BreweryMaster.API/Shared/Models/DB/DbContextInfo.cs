using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        //FermentingIngredients
        public DbSet<FermentingIngredient> FermentingIngredients { get; set; }
        public DbSet<FermentingIngredientTypeEntity> FermentingIngredientTypes { get; set; }
        public DbSet<FermentingIngredientUnit> FermentingIngredientUnits { get; set; }
        public DbSet<FermentingIngredientOrdered> FermentingIngredientsOrdered { get; set; }
        public DbSet<FermentingIngredientStored> FermentingIngredientsStored { get; set; }
        public DbSet<FermentingIngredientReserved> FermentingIngredientsReserved { get; set; }

        //Yeast
        public DbSet<Yeast> Yeast { get; set; }
        public DbSet<YeastForm> YeastForms { get; set; }
        public DbSet<YeastType> YeastTypes { get; set; }
        public DbSet<YeastUnit> YeastUnits { get; set; }
        public DbSet<YeastOrdered> YeastOrdered { get; set; }
        public DbSet<YeastStored> YeastStored { get; set; }
        public DbSet<YeastReserved> YeastReserved { get; set; }

        //Items
        public DbSet<Container> Containers { get; set; }
        public DbSet<ContainerPrice> ContainerPrices { get; set; }
        public DbSet<BeerPrice> BeerPrices { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }

    }
}
