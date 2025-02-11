using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Info.Services
{
    public interface IFermentingIngredientReservationService
    {
        Task<IEnumerable<FermentingIngredientReservationResponse>> GetFermentingIngredientReservations();
        Task<FermentingIngredientReservationResponse?> GetFermentingIngredientReservationById(int id);
        Task<FermentingIngredientReservationResponse?> CreateFermentingIngredientReservation(FermentingIngredientReserveRequest request);
    }
}
