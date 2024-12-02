using BreweryMaster.API.Order.Models.ProspectOrder;

public interface IProspectOrderService
{
    ProspectOrderDetails GetProspectOrderDetails();
    decimal GetEstimatedPrice(PriceEstimationRequest request);
    Task<IEnumerable<ProspectOrder>> GetProspectOrdersAsync();
    Task<ProspectOrder> GetProspectOrderByIdAsync(int id);
    Task<ProspectOrder> CreateProspectOrderAsync(ProspectOrderRequest rder);
    Task<bool> EditProspectOrderAsync(int id, ProspectOrder order);
    Task<bool> DeleteProspectOrderByIdAsync(int id);
}