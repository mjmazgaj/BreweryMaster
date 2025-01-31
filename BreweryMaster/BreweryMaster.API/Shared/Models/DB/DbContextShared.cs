using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        public DbSet<UnitEntity> UnitTypes { get; set; }

    }
}
