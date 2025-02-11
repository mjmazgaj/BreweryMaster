using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Info.Services
{
    public interface IFermentingIngredientService
    {
        Task<IEnumerable<FermentingIngredientResponse>> GetFermentingIngredientsAsync();
        Task<FermentingIngredientResponse?> GetFermentingIngredientByIdAsync(int id);
        Task<IEnumerable<FermentingIngredientSummaryResponse>> GetFermentingIngredientSummary();
        Task<IEnumerable<FermentingIngredientOrderResponse>> GetFermentingIngredientOrders();
        Task<FermentingIngredientOrderResponse?> GetFermentingIngredientOrderById(int id);
        Task<FermentingIngredientSummaryResponse?> GetFermentingIngredientSummaryByIdAsync(int id);
        Task<IEnumerable<FermentingIngredientUnitResponse>?> GetFermentingIngredientUnitAsync();
        Task<IEnumerable<FermentingIngredientUnitNameResponse>?> GetFermentingIngredientUnitNameByIdAsync(int fermentingIngredientId);
        Task<IEnumerable<FermentingIngredientTypeEntityResponse>> GetFermentingIngredientTypesAsync();
        Task<FermentingIngredient> CreateFermentingIngredientAsync(FermentingIngredientRequest request);
        Task<bool> UpdateFermentingIngredientAsync(int id, FermentingIngredientUpdateRequest order);
        Task<bool> DeleteFermentingIngredientByIdAsync(int id);
    }
}