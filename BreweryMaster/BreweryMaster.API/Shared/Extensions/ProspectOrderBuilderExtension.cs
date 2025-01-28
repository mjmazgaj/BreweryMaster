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
                      .HasForeignKey(x => x.ProspectClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.BeerStyle)
                      .WithMany()
                      .HasForeignKey(x => x.BeerStyleId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Container)
                      .WithMany()
                      .HasForeignKey(x => x.ContainerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ProspectCompanyClient>().HasData(OrderDataProvider.GetProspectCompanyClients());
            builder.Entity<ProspectIndyvidualClient>().HasData(OrderDataProvider.GetProspectIndyvidualClients());
            builder.Entity<ProspectOrder>().HasData(OrderDataProvider.GetProspectOrders());
        }
    }
}
