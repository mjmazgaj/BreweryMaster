using BreweryMaster.API.Order.Models;
using BreweryMaster.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Order.Services
{
    public class ProspectClientService : IProspectClientService
    {
        private readonly ApplicationDbContext _context;

        public ProspectClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProspectClient>> GetProspectClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<ProspectClient> GetProspectClientByIdAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<ProspectClient> CreateProspectClientAsync(ProspectClient client)
        {
            var clientToCreate = new ProspectClient()
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

        public async Task<bool> EditProspectClientAsync(int id, ProspectClient client)
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
                if (!ProspectClientExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> DeleteProspectClientByIdAsync(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ID == id);

            if (client == null)
                return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProspectClientExists(int id)
        {
            return _context.Clients.Any(x => x.ID == id);
        }
    }
}
