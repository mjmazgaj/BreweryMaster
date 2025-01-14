using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class EntityBuilderExtension
    {
        public static void ConfigureEntity(this ModelBuilder builder)
        {
            builder.Entity<Container>(entity =>
                entity.HasOne(e => e.UnitEntity)
                      .WithMany()
                      .HasForeignKey(e => e.UnitEntityId)
                      .OnDelete(DeleteBehavior.Cascade)
            );

            builder.Entity<UnitEntity>().HasData(EntityDataProvider.GetUnitEntity());
            builder.Entity<Container>().HasData(EntityDataProvider.GetContainers());
        }
    }
}
