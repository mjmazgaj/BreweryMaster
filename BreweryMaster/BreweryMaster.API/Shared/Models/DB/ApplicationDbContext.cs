using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Info.Models;
using BreweryMaster.API.UserModule.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BreweryMaster.API.Recipe.Models.DB;
using BreweryMaster.API.Shared.Extensions;
using BreweryMaster.API.Info.Models.Item;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.Work.Models.DB;

namespace BreweryMaster.API.Shared.Models.DB
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //User
        public DbSet<IndividualUser> IndividualUsers { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        //Shared
        public DbSet<UnitEntity> Units { get; set; }

        //Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProspectClient> ProspectClients { get; set; }
        public DbSet<ProspectOrder> ProspectOrders { get; set; }

        //Info
        public DbSet<FermentingIngredient> FermentingIngredients { get; set; }
        public DbSet<FermentingIngredientTypeEntity> FermentingIngredientTypes { get; set; }
        public DbSet<FermentingIngredientUnit> FermentingIngredientUnits { get; set; }
        public DbSet<FermentingIngredientOrdered> FermentingIngredientsOrdered { get; set; }
        public DbSet<FermentingIngredientStored> FermentingIngredientsStored { get; set; }
        public DbSet<FermentingIngredientReserved> FermentingIngredientsReserved { get; set; }

        public DbSet<Container> Containers { get; set; }
        public DbSet<Info.Models.Item.ContainerPrice> ContainerPrices { get; set; }
        public DbSet<Info.Models.Item.BeerPrice> BeerPrices { get; set; }

        //Recipe
        public DbSet<BeerStyleEntity> BeerStyles { get; set; }
        public DbSet<Recipe.Models.DB.Recipe> Recipes { get; set; }
        public DbSet<RecipeFermentingIngredient> RecipeFermentingIngredients { get; set; }
        public DbSet<RecipeTypeEntity> RecipeTypes { get; set; }

        //Work KanbanTasks
        public DbSet<KanbanTask> KanbanTasks { get; set; }
        public DbSet<TaskStatusEntity> TaskStatusEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Independent entities
            builder.ConfigureEntity();
            builder.ConfigureItem();

            //User
            builder.ConfigureUser();

            //Dependent entities in proper order
            builder.ConfigureRecipeEntities();
            builder.ConfigureProspectOrder();
            builder.ConfigureFermentingIngredientEntities();
            builder.ConfigureOrder();
            builder.ConfigureKanbanTask();
        }
    }
}