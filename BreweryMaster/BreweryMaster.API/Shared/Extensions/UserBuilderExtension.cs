using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class UserBuilderExtension
    {
        public static void ConfigureUser(this ModelBuilder builder)
        {
            builder.Entity<IndividualUser>().ToTable("IndividualUser");
            builder.Entity<CompanyUser>().ToTable("CompanyUser");


            builder.Entity<CompanyUser>()
                .HasOne(a => a.InvoiceAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasOne(a => a.DeliveryAddress)
                .WithOne(b => b.User)
                .HasForeignKey<Address>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
