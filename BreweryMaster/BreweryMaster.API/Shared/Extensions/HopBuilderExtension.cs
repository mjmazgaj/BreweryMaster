using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class HopBuilderExtension
    {
        public static void ConfigureHopEntities(this ModelBuilder builder)
        {
            builder.ConfigureHopUnit();
            builder.ConfigureHopQuantity();
            builder.ConfigureHopReserved();
        }

        public static void ConfigureHopQuantity(this ModelBuilder builder)
        {
            builder.Entity<HopQuantity>().UseTpcMappingStrategy();
        }

        public static void ConfigureHopReserved(this ModelBuilder builder)
        {
            builder.Entity<HopReserved>(entity =>
            {
                entity.HasOne(x => x.Order)
                    .WithMany()
                    .HasForeignKey(x => x.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public static void ConfigureHopUnit(this ModelBuilder builder)
        {
            builder.Entity<HopUnit>(entity =>
            {
                entity.HasOne(x => x.Hop)
                    .WithMany()
                    .HasForeignKey(x => x.HopId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Unit)
                    .WithMany()
                    .HasForeignKey(x => x.UnitId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.HopsReserved)
                    .WithOne(x => x.HopUnit)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.HopsOrdered)
                    .WithOne(x => x.HopUnit)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.HopsStored)
                    .WithOne(x => x.HopUnit)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
