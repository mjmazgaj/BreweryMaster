using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Info.Services
{
    public interface IFermentingIngredientService
    {
        Task<IEnumerable<FermentingIngredientResponse>> GetFermentingIngredientsAsync();
        Task<FermentingIngredientResponse?> GetFermentingIngredientByIdAsync(int id);
        Task<IEnumerable<FermentingIngredientSummaryResponse>> GetFermentingIngredientSummary(FermentingIngredientFilterRequest? request);
        Task<FermentingIngredientSummaryResponse?> GetFermentingIngredientSummaryByIdAsync(int id);
        Task<IEnumerable<FermentingIngredientUnitResponse>> GetFermentingIngredientUnitAsync();
        Task<IEnumerable<int>?> GetFermentingIngredientUnitsById(int fermentingIngredientId);
        Task<IEnumerable<FermentingIngredientTypeEntityResponse>> GetFermentingIngredientTypesAsync();
        Task<FermentingIngredientResponse?> CreateFermentingIngredientAsync(FermentingIngredientRequest request);
        Task<bool> UpdateFermentingIngredientAsync(int id, FermentingIngredientUpdateRequest request);
        Task<bool> DeleteFermentingIngredientUnitById(int id);
    }
}