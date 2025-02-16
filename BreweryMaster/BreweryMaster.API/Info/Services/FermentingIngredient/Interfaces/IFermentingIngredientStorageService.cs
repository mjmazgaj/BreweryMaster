using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Info.Services
{
    public interface IFermentingIngredientStorageService
    {
        Task<FermentingIngredientStorageResponse?> GetFermentingIngredientStorageById(int id);
        Task<FermentingIngredientStorageResponse?> CreateFermentingIngredientStorage(FermentingIngredientStorageRequest request);
    }
}
