using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Models.User
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Empoyees { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
