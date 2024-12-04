using BreweryMaster.API.OrderModule.Models;

public interface IProspectOrderService
{
    ProspectOrderDetails GetProspectOrderDetails();
    decimal GetEstimatedPrice(ProspectPriceEstimationRequest request);
    Task<IEnumerable<ProspectOrder>> GetProspectOrdersAsync();
    Task<ProspectOrder> GetProspectOrderByIdAsync(int id);
    Task<ProspectOrder> CreateProspectOrderAsync(ProspectOrderRequest rder);
    Task<bool> EditProspectOrderAsync(int id, ProspectOrder order);
    Task<bool> DeleteProspectOrderByIdAsync(int id);
}