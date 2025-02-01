using BreweryMaster.API.Recipe.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class RecipeModelBuilderExtensions
    {
        public static void ConfigureRecipeEntities(this ModelBuilder builder)
        {
            builder.ConfigureRecipe();
            builder.ConfigureRecipeFermentingIngredient();
            builder.ConfigureRecipeHop();
            builder.ConfigureRecipeYeast();
        }

        public static void ConfigureRecipe(this ModelBuilder builder)
        {
            builder.Entity<Recipe.Models.DB.Recipe>(entity =>
            {
                entity.HasOne(e => e.Style)
                      .WithMany()
                      .HasForeignKey(e => e.StyleId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Type)
                      .WithMany()
                      .HasForeignKey(e => e.TypeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(r => r.FermentingIngredients)
                      .WithOne(fiu => fiu.Recipe)
                      .HasForeignKey(fiu => fiu.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public static void ConfigureRecipeFermentingIngredient(this ModelBuilder builder)
        {
            builder.Entity<RecipeFermentingIngredient>(entity =>
            {
                entity.HasKey(e => new { e.FermentingIngredientUnitId, e.RecipeId });

                entity.HasOne(e => e.Recipe)
                      .WithMany(e => e.FermentingIngredients)
                      .HasForeignKey(e => e.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.FermentingIngredientUnit)
                      .WithMany()
                      .HasForeignKey(e => e.FermentingIngredientUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public static void ConfigureRecipeHop(this ModelBuilder builder)
        {
            builder.Entity<RecipeHop>(entity =>
            {
                entity.HasKey(e => new { e.HopUnitId, e.RecipeId });

                entity.HasOne(e => e.Recipe)
                      .WithMany(e => e.RecipeHops)
                      .HasForeignKey(e => e.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.HopUnit)
                      .WithMany()
                      .HasForeignKey(e => e.HopUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public static void ConfigureRecipeYeast(this ModelBuilder builder)
        {
            builder.Entity<RecipeYeast>(entity =>
            {
                entity.HasKey(e => new { e.YeastUnitId, e.RecipeId });

                entity.HasOne(e => e.Recipe)
                      .WithMany(e => e.RecipeYeasts)
                      .HasForeignKey(e => e.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.YeastUnit)
                      .WithMany()
                      .HasForeignKey(e => e.YeastUnitId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
