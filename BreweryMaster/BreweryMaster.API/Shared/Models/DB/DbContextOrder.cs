using BreweryMaster.API.Info.Models;
using BreweryMaster.API.OrderModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderStatusChange> OrderStatusChanges { get; set; }
        public DbSet<ProspectClient> ProspectClients { get; set; }
        public DbSet<ProspectOrder> ProspectOrders { get; set; }
    }
}
