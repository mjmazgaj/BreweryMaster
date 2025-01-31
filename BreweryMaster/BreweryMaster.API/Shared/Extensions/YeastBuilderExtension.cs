using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Models.DB.Yeast;
using BreweryMaster.API.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class YeastBuilderExtension
    {
        public static void ConfigureYeastEntities(this ModelBuilder builder)
        {
            builder.ConfigureYeast();
            builder.ConfigureYeastUnit();
            builder.ConfigureYeastQuantity();
            builder.ConfigureYeastOrdered();
            builder.ConfigureYeastReserved();
            builder.ConfigureYeastStored();
        }

        public static void ConfigureYeast(this ModelBuilder builder)
        {
            builder.Entity<Yeast>(entity =>
            {
                entity.HasOne(x => x.Type)
                      .WithMany()
                      .HasForeignKey(e => e.TypeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Form)
                      .WithMany()
                      .HasForeignKey(e => e.FormId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(YeastDataProvider.GetYeasts());
            });

            builder.Entity<YeastForm>().HasData(YeastDataProvider.GetYeastForm());
            builder.Entity<YeastType>().HasData(YeastDataProvider.GetYeastType());
        }

        public static void ConfigureYeastQuantity(this ModelBuilder builder)
        {
            builder.Entity<YeastQuantity>().UseTpcMappingStrategy();
        }

        public static void ConfigureYeastOrdered(this ModelBuilder builder)
        {
            builder.Entity<YeastOrdered>().HasData(YeastDataProvider.GetYeastOrdered());
        }

        public static void ConfigureYeastReserved(this ModelBuilder builder)
        {
            builder.Entity<YeastReserved>(entity =>
            {
                entity.HasOne(x => x.Order)
                    .WithMany()
                    .HasForeignKey(x => x.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<YeastReserved>().HasData(YeastDataProvider.GetYeastReserved());
        }

        public static void ConfigureYeastStored(this ModelBuilder builder)
        {
            builder.Entity<YeastStored>().HasData(YeastDataProvider.GetYeastStored());
        }

        public static void ConfigureYeastUnit(this ModelBuilder builder)
        {
            builder.Entity<YeastUnit>(entity =>
            {
                entity.HasOne(x => x.Yeast)
                    .WithMany()
                    .HasForeignKey(x => x.YeastId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Unit)
                    .WithMany()
                    .HasForeignKey(x => x.UnitId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.YeastReserved)
                    .WithOne(x => x.YeastUnit)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.YeastOrdered)
                    .WithOne(x => x.YeastUnit)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.YeastStored)
                    .WithOne(x => x.YeastUnit)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(YeastDataProvider.GetYeastUnit());
            });
        }
    }
}
