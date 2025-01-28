using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Services
{
    public class EntityService : IEntityService
    {
        private readonly ApplicationDbContext _context;
        public EntityService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EntityResponse>> GetUnitsAsync()
        {
            return await _context.Units.Select(x =>
            new EntityResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
