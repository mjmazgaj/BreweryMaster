using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Info.Services
{
    public interface IFermentingIngredientOrderService
    {
        Task<IEnumerable<FermentingIngredientOrderResponse>> GetFermentingIngredientOrders();
        Task<FermentingIngredientOrderResponse?> GetFermentingIngredientOrderById(int id);
    }
}
