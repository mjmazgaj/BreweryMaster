using BreweryMaster.API.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Services
{
    public class ClientService : IClientService
    {
        private readonly UserContext _context;

        public ClientService(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            var clientToCreate = new Client()
            {
                Forename = client.Forename,
                Surname = client.Surname,
                CompanyName = client.CompanyName,
                NIP = client.NIP,
                AddressId = client.AddressId,
                DeliveryAddressId = client.DeliveryAddressId,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email
            };

            _context.Clients.Add(clientToCreate);
            await _context.SaveChangesAsync();

            return clientToCreate;
        }

        public async Task<bool> EditClientAsync(int id, Client client)
        {
            if (id != client.ID)
                return false;

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> DeleteClientByIdAsync(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ID == id);

            if (client == null)
                return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(x => x.ID == id);
        }
    }
}
