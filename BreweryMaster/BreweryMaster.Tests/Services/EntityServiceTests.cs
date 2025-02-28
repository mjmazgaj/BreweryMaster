using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.Tests.Services
{
    public class EntityServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        public EntityServiceTests()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!_dbContext.UnitTypes.Any())
                _dbContext.UnitTypes.AddRange(EntityDataProvider.GetUnitEntity());

            if (!_dbContext.TaskStatusEntities.Any())
                _dbContext.TaskStatusEntities.AddRange(EntityDataProvider.GetTaskStatusEntities());

            _dbContext.SaveChanges();
        }
    }
}
