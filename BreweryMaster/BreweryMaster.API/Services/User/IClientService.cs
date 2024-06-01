using BreweryMaster.API.Models.User;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> GetClientByIdAsync(int id);
    Task<Client> CreateClientAsync(Client client);
    Task<bool> EditClientAsync(int id, Client client);
    Task<bool> DeleteClientByIdAsync(int id);
}