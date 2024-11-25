using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Work.Models
{
    public class WorkDbContext : DbContext
    {
        public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options)
        {
        }

        public DbSet<KanbanTask> KanbanTasks { get; set; }
    }
}
