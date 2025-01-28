using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.Shared.Services
{
    public interface IEntityService
    {
        Task<IEnumerable<EntityResponse>> GetUnitsAsync();
    }
}