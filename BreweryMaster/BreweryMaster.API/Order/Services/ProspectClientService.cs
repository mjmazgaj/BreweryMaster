using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BreweryMaster.API.OrderModule.Services
{
    public class ProspectClientService : IProspectClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderSettings _settings;

        public ProspectClientService(ApplicationDbContext context, IOptions<OrderSettings> options)
        {
            _context = context;
            _settings = options.Value;
        }

        public async Task<IEnumerable<ProspectClientResponse>> GetProspectClientsAsync()
        {
            return await _context.ProspectClients.Select(x => new ProspectClientResponse()
            {
                Id = x.Id,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            }).ToListAsync();
        }

        public async Task<IEnumerable<EntityResponse>> GetProspectClientDropDownList()
        {
            return await _context.ProspectClients.Select(x => new EntityResponse()
            {
                Id = x.Id,
                Name = x.Email,
            }).ToListAsync();
        }

        public async Task<ProspectClientResponse?> GetProspectClientByIdAsync(int id)
        {
            return await _context.ProspectClients.Select(x => new ProspectClientResponse()
            {
                Id = x.Id,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProspectClient> CreateProspectClientAsync(ProspectClientRequest request)
        {
            var clientToCreate = new ProspectClient()
            {
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
            };

            _context.ProspectClients.Add(clientToCreate);
            await _context.SaveChangesAsync();

            return clientToCreate;
        }

        public async Task<bool> EditProspectClientAsync(int id, ProspectClientResponse client)
        {
            if (id != client.Id)
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
            var client = await _context.ProspectClients.FirstOrDefaultAsync(x => x.Id == id);

            if (client == null)
                return false;

            _context.ProspectClients.Remove(client);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProspectClientExists(int id)
        {
            return _context.ProspectClients.Any(x => x.Id == id);
        }
    }
}
