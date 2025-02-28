using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.User.Services;
using BreweryMaster.Tests.Helpers;
using BreweryMaster.Tests.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace BreweryMaster.Tests.Services
{
    public class UserServiceTests
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly Mock<IAddressService> _addressService;

        public UserServiceTests()
        {
            _addressService = new Mock<IAddressService>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UserDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            var userStore = new Mock<IUserStore<ApplicationUser>>().Object;
            var optionsAccessor = new Mock<IOptions<IdentityOptions>>().Object;
            var passwordHasher = new Mock<IPasswordHasher<ApplicationUser>>().Object;
            var userValidators = new List<IUserValidator<ApplicationUser>>();
            var passwordValidators = new List<IPasswordValidator<ApplicationUser>>();
            var keyNormalizer = new Mock<ILookupNormalizer>().Object;
            var errors = new Mock<IdentityErrorDescriber>().Object;
            var services = new Mock<IServiceProvider>().Object;
            var logger = new Mock<ILogger<UserManager<ApplicationUser>>>().Object;

            _userManager = new UserManager<ApplicationUser>(userStore, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger);

            var roleStore = new Mock<IRoleStore<IdentityRole>>().Object;
            var roleValidators = new List<IRoleValidator<IdentityRole>>();
            var roleLogger = new Mock<ILogger<RoleManager<IdentityRole>>>().Object;

            _roleManager = new RoleManager<IdentityRole>(roleStore, roleValidators, keyNormalizer, errors, roleLogger);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.Users.Any())
                _dbContext.Users.AddRange(UserDataProvider.GetUsers());

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, TestConst.String)]
        [InlineData(null, TestConst.Date, TestConst.Date, TestConst.String)]
        [InlineData(TestConst.String, null, TestConst.Date, TestConst.String)]
        [InlineData(TestConst.String, TestConst.Date, null, TestConst.String)]
        [InlineData(TestConst.String, TestConst.Date, TestConst.Date, null)]
        public async Task GetUsers_ShouldFilter_ByProvidedParameters(string? email, string? createdAfterString, string? createdBeforeString, string? roleId)
        {
            // Arrange
            var service = new UserService(_userManager, _roleManager, _dbContext, _addressService.Object);

            DateTime? createdAfter = string.IsNullOrEmpty(createdAfterString) ? null : DateTime.Parse(createdAfterString);
            DateTime? createdBefore = string.IsNullOrEmpty(createdBeforeString) ? null : DateTime.Parse(createdBeforeString);

            var request = new UserFilterRequest
            {
                Email = email,
                CreatedAfter = createdAfter,
                CreatedBefore = createdBefore,
                RoleId = roleId
            };

            var expectedResult = _dbContext.CompanyUsers
                                    .Where(x => !x.IsRemoved)
                                    .Where(x => request.Email == null || x.Email == null || x.Email.Contains(request.Email))
                                    .Where(x => request.CreatedAfter == null || x.CreatedOn >= request.CreatedAfter)
                                    .Where(x => request.CreatedBefore == null || x.CreatedOn <= request.CreatedBefore)
                                    .ToList();
            // Act
            var result = await service.GetUsers(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Count, result.Count());
        }
    }
}
