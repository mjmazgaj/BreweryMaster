using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models;

public interface IProspectClientService
{
    Task<IEnumerable<ProspectClientResponse>> GetProspectClientsAsync();
    Task<IEnumerable<EntityResponse>> GetProspectClientDropDownList();
    Task<ProspectClientResponse?> GetProspectClientByIdAsync(int id);
    Task<ProspectClient> CreateProspectClientAsync(ProspectClientRequest client);
    Task<bool> EditProspectClientAsync(int id, ProspectClientUpdateRequest client);
    Task<bool> DeleteProspectClientByIdAsync(int id);
}