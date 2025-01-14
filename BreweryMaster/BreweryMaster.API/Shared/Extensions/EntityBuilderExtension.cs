using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class EntityBuilderExtension
    {
        public static void ConfigureEntity(this ModelBuilder builder)
        {
            builder.Entity<UnitEntity>().HasData(EntityDataProvider.GetUnitEntity());
        }
    }
}
