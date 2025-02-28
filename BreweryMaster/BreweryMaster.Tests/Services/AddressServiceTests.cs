using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Services;
using BreweryMaster.API.UserModule.Models;
using BreweryMaster.Tests.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class AddressServiceTests
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddressDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (_dbContext.Addresses.Any())
                return;

            var address1 = new Address
            {
                City = TestConst.String,
                Street = TestConst.String,
                HouseNumber = TestConst.String,
                PostalCode = TestConst.String,
                Commune = TestConst.String,
                Region = TestConst.String,
                Country = TestConst.String
            };

            var address2 = new Address
            {
                City = TestConst.String2,
                Street = TestConst.String2,
                HouseNumber = TestConst.String2,
                PostalCode = TestConst.String2,
                Commune = TestConst.String2,
                Region = TestConst.String2,
                Country = TestConst.String2
            };

            _dbContext.Addresses.AddRange(address1, address2);

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetAddressById_ShouldReturn_CorrectAddress()
        {
            // Arrange
            var service = new AddressService(_dbContext);
            int addressId = 1;

            // Act
            var result = await service.GetAddressById(addressId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addressId, result.Id);
            Assert.Equal(TestConst.String, result.City);
            Assert.Equal(TestConst.String, result.Street);
            Assert.Equal(TestConst.String, result.HouseNumber);
            Assert.Equal(TestConst.String, result.PostalCode);
            Assert.Equal(TestConst.String, result.Commune);
            Assert.Equal(TestConst.String, result.Region);
            Assert.Equal(TestConst.String, result.Country);
        }
    }
}
