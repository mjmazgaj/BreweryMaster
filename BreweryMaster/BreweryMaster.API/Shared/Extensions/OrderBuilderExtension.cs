using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class OrderBuilderExtension
    {
        public static void ConfigureOrder(this ModelBuilder builder)
        {
            builder.Entity<Order>(entity =>
            {
                entity.HasOne(x => x.Container)
                      .WithMany()
                      .HasForeignKey(x => x.ContainerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Recipe)
                      .WithMany()
                      .HasForeignKey(x => x.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.User)
                      .WithMany()
                      .HasForeignKey(x => x.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
