using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class ItemBuilderExtension
    {
        public static void ConfigureItem(this ModelBuilder builder)
        {
            builder.Entity<ItemPrice>().UseTpcMappingStrategy();

            builder.Entity<Container>(entity =>
                entity.HasOne(e => e.UnitEntity)
                      .WithMany()
                      .HasForeignKey(e => e.UnitEntityId)
                      .OnDelete(DeleteBehavior.Cascade)
            );

            builder.Entity<Container>(entity =>
                entity.HasOne(e => e.Material)
                      .WithMany()
                      .HasForeignKey(e => e.MaterialId)
                      .OnDelete(DeleteBehavior.Cascade)
            );

            builder.Entity<BeerPrice>(entity =>
                entity.HasOne(e => e.BeerStyle)
                      .WithMany()
                      .HasForeignKey(e => e.BeerStyleId)
                      .OnDelete(DeleteBehavior.Cascade)
            );

            builder.Entity<ContainerPrice>(entity =>
                entity.HasOne(e => e.Container)
                      .WithMany()
                      .HasForeignKey(e => e.ContainerId)
                      .OnDelete(DeleteBehavior.Cascade)
            );
        }
    }
}