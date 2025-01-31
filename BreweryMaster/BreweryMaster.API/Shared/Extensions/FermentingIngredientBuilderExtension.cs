using BreweryMaster.API.Info.Models;
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
            builder.ConfigureFermentingIngredientReserved();
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
        }

        public static void ConfigureFermentingIngredientQuantity(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientQuantity>().UseTpcMappingStrategy();
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
