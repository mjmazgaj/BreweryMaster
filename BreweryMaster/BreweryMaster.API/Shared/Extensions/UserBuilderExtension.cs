using BreweryMaster.API.User.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class UserBuilderExtension
    {
        public static void ConfigureUser(this ModelBuilder builder)
        {
            builder.Entity<IndividualUser>().ToTable("IndividualUser");
            builder.Entity<CompanyUser>().ToTable("CompanyUser");


            builder.Entity<IndividualUser>()
                .HasOne(a => a.DeliveryAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CompanyUser>()
                .HasOne(a => a.InvoiceAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CompanyUser>()
                .HasOne(a => a.DeliveryAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
