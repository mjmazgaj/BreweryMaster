using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.User.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class OrderBuilderExtension
    {
        public static void ConfigureOrder(this ModelBuilder builder)
        {
            builder.Entity<IndyvidualClient>().ToTable("IndyvidualClients");
            builder.Entity<CompanyClient>().ToTable("CompanyClients");

            builder.Entity<ClientAddress>()
                .HasKey(x => new { x.ClientId, x.AddressId, x.AddressTypeId });

            builder.Entity<OrderStatusChange>()
                .HasKey(x => new { x.OrderId, x.OrderStatusId });

            builder.Entity<Order>(entity =>
            {
                entity.HasOne(x => x.Client)
                      .WithMany(x => x.Orders)
                      .HasForeignKey(x => x.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Container)
                      .WithMany()
                      .HasForeignKey(x => x.ContainerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Recipe)
                      .WithMany()
                      .HasForeignKey(x => x.RecipeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.CreatedByUser)
                      .WithMany()
                      .HasForeignKey(x => x.CreatedByUserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<OrderStatusChange>(entity =>
            {
                entity.HasOne(x => x.Order)
                       .WithMany(x => x.OrderStatusChanges)
                       .HasForeignKey(x => x.OrderId)
                       .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.OrderStatus)
                       .WithMany()
                       .HasForeignKey(x => x.OrderStatusId)
                       .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
