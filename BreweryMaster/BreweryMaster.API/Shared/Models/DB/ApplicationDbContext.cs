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

            builder.ConfigureUser();
            builder.ConfigureItem();
            builder.ConfigureRecipeEntities();
            builder.ConfigureProspectOrder();
            builder.ConfigureFermentingIngredientEntities();
            builder.ConfigureYeastEntities();
            builder.ConfigureOrder();
            builder.ConfigureKanbanTask();

            //Provide data
            builder.AddIndependentEntities();
            builder.AddEntitiesSimpleDepend();
            builder.AddProspectOrderEntities();
            builder.AddFermentingIngredientEntities();
            builder.AddYeastEntities();
            builder.AddRecipeEntities();
        }
    }
}