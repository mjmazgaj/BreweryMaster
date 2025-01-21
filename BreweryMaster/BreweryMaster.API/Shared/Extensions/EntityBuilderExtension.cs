using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.Work.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class EntityBuilderExtension
    {
        public static void ConfigureEntity(this ModelBuilder builder)
        {
            builder.Entity<UnitEntity>().HasData(EntityDataProvider.GetUnitEntity());
            builder.Entity<TaskStatusEntity>().HasData(EntityDataProvider.GetTaskStatusEntities());
        }
    }
}
