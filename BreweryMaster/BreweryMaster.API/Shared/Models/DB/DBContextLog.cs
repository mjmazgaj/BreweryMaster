using BreweryMaster.API.Log.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        public DbSet<ChangeLog> ChangeLogs { get; set; }
    }
}
