using BreweryMaster.API.User.Models;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> GetClientByIdAsync(int id);
    Task<Client> CreateClientAsync(Client client);
    Task<bool> EditClientAsync(int id, Client client);
    Task<bool> DeleteClientByIdAsync(int id);
}