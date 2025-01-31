using BreweryMaster.API.Info.Models;
using BreweryMaster.API.User.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class FermentingIngredientBuilderExtension
    {
        public static void ConfigureFermentingIngredientEntities(this ModelBuilder builder)
        {
            builder.ConfigureFermentingIngredient();
            builder.ConfigureFermentingIngredientUnit();
            builder.ConfigureFermentingIngredientQuantity();
            builder.ConfigureFermentingIngredientOrdered();
            builder.ConfigureFermentingIngredientReserved();
            builder.ConfigureFermentingIngredientStored();
        }

        public static void ConfigureFermentingIngredient(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredient>(entity =>
            {
                entity.HasOne(x => x.Type)
                      .WithMany()
                      .HasForeignKey(e => e.TypeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredientTypeEntity>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientTypeEntity());
            builder.Entity<FermentingIngredient>().HasData(FermentingIngredientDataProvider.GetFermentingIngredient());
            builder.Entity<FermentingIngredientUnit>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientUnit());
        }
        public static void ConfigureFermentingIngredientQuantity(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientQuantity>().UseTpcMappingStrategy();
        }

        public static void ConfigureFermentingIngredientOrdered(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientOrdered>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientOrdered());
        }
        public static void ConfigureFermentingIngredientReserved(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientReserved>(entity =>
            {
                entity.HasOne(x => x.Order)
                    .WithMany()
                    .HasForeignKey(x => x.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<FermentingIngredientReserved>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientReserved());
        }

        public static void ConfigureFermentingIngredientStored(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientStored>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientStored());
        }

        public static void ConfigureFermentingIngredientUnit(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientUnit>(entity =>
            {
                entity.HasOne(x => x.FermentingIngredient)
                    .WithMany()
                    .HasForeignKey(x => x.FermentingIngredientId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Unit)
                    .WithMany()
                    .HasForeignKey(x => x.UnitId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.FermentingIngredientsReserved)
                    .WithOne(x => x.FermentingIngredientUnit)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.FermentingIngredientsOrdered)
                    .WithOne(x => x.FermentingIngredientUnit)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.FermentingIngredientsStored)
                    .WithOne(x => x.FermentingIngredientUnit)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
