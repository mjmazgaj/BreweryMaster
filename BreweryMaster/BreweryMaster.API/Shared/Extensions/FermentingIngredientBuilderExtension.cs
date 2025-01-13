using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class FermentingIngredientBuilderExtension
    {
        public static void ConfigureFermentingIngredientEntities(this ModelBuilder builder)
        {
            builder.ConfigureFermentingIngredient();
            builder.ConfigureFermentingIngredientOrdered();
            builder.ConfigureFermentingIngredientReserved();
            builder.ConfigureFermentingIngredientStored();
        }

        public static void ConfigureFermentingIngredient(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredient>(entity =>
            {
                entity.HasOne(x => x.FermentingIngredientTypeEntity)
                      .WithMany()
                      .HasForeignKey(e => e.TypeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredientTypeEntity>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientTypeEntity());
            builder.Entity<FermentingIngredient>().HasData(FermentingIngredientDataProvider.GetFermentingIngredient());
            builder.Entity<FermentingIngredientUnit>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientUnit());
        }

        public static void ConfigureFermentingIngredientOrdered(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientOrdered>(entity =>
            {
                entity.HasOne(x => x.FermentingIngredientUnit)
                      .WithMany()
                      .HasForeignKey(e => e.FermentingIngredientUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredientOrdered>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientOrdered());
        }
        public static void ConfigureFermentingIngredientReserved(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientReserved>(entity =>
            {
                entity.HasOne(x => x.FermentingIngredientUnit)
                      .WithMany()
                      .HasForeignKey(e => e.FermentingIngredientUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredientReserved>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientReserved());
        }

        public static void ConfigureFermentingIngredientStored(this ModelBuilder builder)
        {
            builder.Entity<FermentingIngredientStored>(entity =>
            {
                entity.HasOne(x => x.FermentingIngredientUnit)
                      .WithMany()
                      .HasForeignKey(e => e.FermentingIngredientUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<FermentingIngredientStored>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientStored());
        }
    }
}
