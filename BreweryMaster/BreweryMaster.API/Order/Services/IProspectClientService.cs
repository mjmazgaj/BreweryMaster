using BreweryMaster.API.Order.Models;

public interface IProspectClientService
{
    Task<IEnumerable<ProspectClient>> GetProspectClientsAsync();
    Task<ProspectClient> GetProspectClientByIdAsync(int id);
    Task<ProspectClient> CreateProspectClientAsync(ProspectClient client);
    Task<bool> EditProspectClientAsync(int id, ProspectClient client);
    Task<bool> DeleteProspectClientByIdAsync(int id);
}