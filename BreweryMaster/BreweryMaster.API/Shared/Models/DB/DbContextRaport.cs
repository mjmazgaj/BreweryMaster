using BreweryMaster.API.RaportModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        public DbSet<Raport> Raports { get; set; }
        public DbSet<RaportCategory> RaportCategories { get; set; }
    }
}
