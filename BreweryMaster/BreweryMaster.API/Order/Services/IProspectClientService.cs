using BreweryMaster.API.Order.Models.ProspectOrder;

public interface IProspectClientService
{
    ProspectOrderDetails GetProspectOrderDetails();
    decimal GetEstimatedPrice(PriceEstimationRequest request);
    Task<IEnumerable<ProspectClient>> GetProspectClientsAsync();
    Task<ProspectClient> GetProspectClientByIdAsync(int id);
    Task<ProspectClient> CreateProspectClientAsync(ProspectClientRequest client);
    Task<bool> EditProspectClientAsync(int id, ProspectClient client);
    Task<bool> DeleteProspectClientByIdAsync(int id);
}