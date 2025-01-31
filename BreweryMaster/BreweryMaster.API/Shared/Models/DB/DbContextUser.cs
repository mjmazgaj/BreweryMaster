using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.UserModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        public DbSet<IndividualUser> IndividualUsers { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<AddressTypeEntity> AddressTypes { get; set; }
    }
}
