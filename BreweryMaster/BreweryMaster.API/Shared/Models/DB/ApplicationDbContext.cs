using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Info.Models;
using BreweryMaster.API.UserModule.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BreweryMaster.API.User.Models.DB;

namespace BreweryMaster.API.Shared.Models.DB
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UnitEntity> Units { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ProspectClient> ProspectClients { get; set; }
        public DbSet<ProspectOrder> ProspectOrders { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<FermentingIngredient> FermentingIngredients { get; set; }
        public DbSet<FermentingIngredientTypeEntity> FermentingIngredientTypes { get; set; }
        public DbSet<FermentingIngredientUnit> FermentingIngredientUnits { get; set; }
        public DbSet<FermentingIngredientOrdered> FermentingIngredientsOrdered { get; set; }
        public DbSet<FermentingIngredientStored> FermentingIngredientsStored { get; set; }
        public DbSet<FermentingIngredientReserved> FermentingIngredientsReserved { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FermentingIngredientOrdered>(entity =>
            {
                entity.HasOne<FermentingIngredientUnit>()
                      .WithMany()
                      .HasForeignKey(e => e.FermentingIngredientUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredientStored>(entity =>
            {
                entity.HasOne<FermentingIngredientUnit>()
                      .WithMany()
                      .HasForeignKey(e => e.FermentingIngredientUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredientReserved>(entity =>
            {
                entity.HasOne<FermentingIngredientUnit>()
                      .WithMany()
                      .HasForeignKey(e => e.FermentingIngredientUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredient>(entity =>
            {
                entity.HasOne<FermentingIngredientTypeEntity>()
                      .WithMany()
                      .HasForeignKey(e => e.TypeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredientTypeEntity>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientTypeEntity());
            builder.Entity<UnitEntity>().HasData(DataProvider.GetUnitEntity());
            builder.Entity<FermentingIngredient>().HasData(FermentingIngredientDataProvider.GetFermentingIngredient());
            builder.Entity<FermentingIngredientUnit>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientUnit());
            builder.Entity<FermentingIngredientOrdered>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientOrdered());
            builder.Entity<FermentingIngredientReserved>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientReserved());
            builder.Entity<FermentingIngredientStored>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientStored());
        }
    }
}