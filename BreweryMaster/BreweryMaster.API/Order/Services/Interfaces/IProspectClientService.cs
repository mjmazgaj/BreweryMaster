using BreweryMaster.API.OrderModule.Models;

public interface IProspectClientService
{
    Task<IEnumerable<ProspectClientResponse>> GetProspectClientsAsync();
    Task<ProspectClientResponse?> GetProspectClientByIdAsync(int id);
    Task<ProspectClient> CreateProspectClientAsync(ProspectClientRequest client);
    Task<bool> EditProspectClientAsync(int id, ProspectClientResponse client);
    Task<bool> DeleteProspectClientByIdAsync(int id);
}