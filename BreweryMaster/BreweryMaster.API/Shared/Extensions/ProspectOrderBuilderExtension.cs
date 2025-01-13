using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class ProspectOrderBuilderExtension
    {
        public static void ConfigureProspectOrder(this ModelBuilder builder)
        {
            builder.Entity<ProspectIndyvidualClient>().ToTable("ProspectIndyvidualClient");
            builder.Entity<ProspectCompanyClient>().ToTable("ProspectCompanyClient");

            builder.Entity<ProspectOrder>(entity =>
            {
                entity.HasOne(x => x.ProspectClient)
                      .WithMany(x=>x.Orders)
                      .HasForeignKey(x => x.ProspectClientId);
            });

            builder.Entity<ProspectCompanyClient>().HasData(ProspectOrderDataProvider.GetProspectCompanyClients());
            builder.Entity<ProspectIndyvidualClient>().HasData(ProspectOrderDataProvider.GetProspectIndyvidualClients());
            builder.Entity<ProspectOrder>().HasData(ProspectOrderDataProvider.GetProspectOrders());
        }
    }
}
