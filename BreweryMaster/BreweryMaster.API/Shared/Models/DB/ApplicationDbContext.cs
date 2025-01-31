using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BreweryMaster.API.Shared.Extensions;
using BreweryMaster.API.User.Models.Users.DB;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Independent entities
            builder.ConfigureEntity();
            builder.ConfigureItem();
            builder.ConfigureRecipeEntities();

            //User
            builder.ConfigureUser();

            //Dependent entities in proper order
            builder.ConfigureRecipe();
            builder.ConfigureRecipeFermentingIngredient();

            builder.ConfigureProspectOrder();
            builder.ConfigureFermentingIngredientEntities();
            builder.ConfigureYeastEntities();
            builder.ConfigureOrder();
            builder.ConfigureKanbanTask();
        }
    }
}