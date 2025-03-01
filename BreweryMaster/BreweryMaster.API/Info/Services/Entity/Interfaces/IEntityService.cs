using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.Info.Services
{
    public interface IEntityService
    {
        Task<IEnumerable<EntityResponse>> GetUnitsAsync();
        Task<IEnumerable<EntityResponse>> GetContainers();
    }
}