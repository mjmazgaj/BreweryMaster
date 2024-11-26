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
            return await _context.ProspectClients.ToListAsync();
        }

        public async Task<ProspectClient> GetProspectClientByIdAsync(int id)
        {
            return await _context.ProspectClients.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<ProspectClient> CreateProspectClientAsync(ProspectClientRequest request)
        {
            var clientToCreate = new ProspectClient()
            {
                Forename = request.Forename,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
            };

            _context.ProspectClients.Add(clientToCreate);
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
            var client = await _context.ProspectClients.FirstOrDefaultAsync(x => x.ID == id);

            if (client == null)
                return false;

            _context.ProspectClients.Remove(client);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProspectClientExists(int id)
        {
            return _context.ProspectClients.Any(x => x.ID == id);
        }
    }
}
