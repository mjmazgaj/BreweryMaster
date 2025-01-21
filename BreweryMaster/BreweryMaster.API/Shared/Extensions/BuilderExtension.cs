using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.Work.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class BuilderExtension
    {
        public static void ConfigureKanbanTask(this ModelBuilder builder)
        {
            builder.Entity<KanbanTask>(entity =>
            {
                entity.HasOne(x => x.AssignedTo)
                      .WithMany()
                      .HasForeignKey(x => x.AssignedToId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.CreatedBy)
                      .WithMany()
                      .HasForeignKey(x => x.CreatedById)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Order)
                      .WithMany()
                      .HasForeignKey(x => x.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //builder.Entity<KanbanTask>().HasData(KanbanTaskDataProvider.GetKanbanTasks());
        }
    }
}
