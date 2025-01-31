using BreweryMaster.API.Work.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        public DbSet<KanbanTask> KanbanTasks { get; set; }
        public DbSet<TaskStatusEntity> TaskStatusEntities { get; set; }
    }
}
