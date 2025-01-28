using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Users.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class UserBuilderExtension
    {
        public static void ConfigureUser(this ModelBuilder builder)
        {
            builder.Entity<IndividualUser>().ToTable("IndividualUser");
            builder.Entity<CompanyUser>().ToTable("CompanyUser");
            builder.Entity<UserAddress>()
                .HasKey(ua => new { ua.UserId, ua.AddressId, ua.AddressTypeId });

            builder.Entity<UserAddress>()
                .HasOne(x =>x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserAddress>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserAddress>()
                .HasOne(x => x.AddressType)
                .WithMany()
                .HasForeignKey(x => x.AddressTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(x => x.UserAddresses)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
