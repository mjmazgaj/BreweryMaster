using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Helpers
{
    public static class UserHelper
    {
        public static void ConfigureUser(this ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasOne(a => a.Address)
                .WithOne(b => b.User)
                .HasForeignKey<Address>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
