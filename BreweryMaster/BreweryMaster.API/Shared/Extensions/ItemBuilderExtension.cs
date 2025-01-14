using BreweryMaster.API.Info.Models.Item;
using BreweryMaster.API.OrderModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class ItemBuilderExtension
    {
        public static void ConfigureItem(this ModelBuilder builder)
        {
            builder.Entity<Container>(entity =>
                entity.HasOne(e => e.UnitEntity)
                      .WithMany()
                      .HasForeignKey(e => e.UnitEntityId)
                      .OnDelete(DeleteBehavior.Cascade)
            );

            builder.Entity<Container>().HasData(ItemDataProvider.GetContainers());
            builder.Entity<Info.Models.Item.ContainerPrice>().HasData(ItemDataProvider.GetContainerPrices());
            builder.Entity<Info.Models.Item.BeerPrice>().HasData(ItemDataProvider.GetBeerPrices());
        }
    }
}
