using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Shared.Models.DB;

namespace BreweryMaster.API.Info.Services.Interfaces
{
    public interface IFermentingIngredientService
    {
        Task<IEnumerable<FermentingIngredientResponse>> GetFermentingIngredientsAsync();
        Task<FermentingIngredientResponse?> GetFermentingIngredientByIdAsync(int id);
        Task<IEnumerable<FermentingIngredientSummaryResponse>> GetFermentingIngredientSummary();
        Task<FermentingIngredientSummaryResponse?> GetFermentingIngredientSummaryByIdAsync(int id);
        Task<IEnumerable<FermentingIngredientUnitNameResponse>?> GetFermentingIngredientUnitNameByIdAsync(int fermentingIngredientId);
        Task<IEnumerable<FermentingIngredientTypeEntityResponse>> GetFermentingIngredientTypesAsync();
        Task<FermentingIngredient> CreateFermentingIngredientAsync(FermentingIngredientRequest request);
        Task<bool> UpdateFermentingIngredientAsync(int id, FermentingIngredientUpdateRequest order);
        Task<bool> DeleteFermentingIngredientByIdAsync(int id);
    }
}