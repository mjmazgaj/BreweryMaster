using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.OrderModule.Services
{
    public class ProspectClientService : IProspectClientService
    {
        private readonly ApplicationDbContext _context;

        public ProspectClientService(ApplicationDbContext context)
        {
            _context = context;
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

            if (request.IsCompany)
            {
                if (request.CompanyClient is null)
                    throw new ArgumentNullException($"{typeof(ProspectClientCompanyRequest)} can not be null");

                var companyClientToCreate = (ProspectCompanyClient)clientToCreate;

                companyClientToCreate.CompanyName = request.CompanyClient.CompanyName;
                companyClientToCreate.Nip = request.CompanyClient.Nip;

                _context.ProspectClients.Add(clientToCreate);
            }
            else
            {
                if (request.IndividualClient is null)
                    throw new ArgumentNullException($"{typeof(ProspectClientIndividualRequest)} can not be null");

                var individualClientToCreate = (ProspectIndyvidualClient)clientToCreate;

                individualClientToCreate.Forename = request.IndividualClient.Forename;
                individualClientToCreate.Surname = request.IndividualClient.Surname;

                _context.ProspectClients.Add(clientToCreate);
            }

            await _context.SaveChangesAsync();

            return clientToCreate;
        }

        public async Task<bool> EditProspectClientAsync(int id, ProspectClientUpdateRequest request)
        {
            var clientToUpdate = await _context.ProspectClients.FirstOrDefaultAsync(x => x.Id == id);

            if (clientToUpdate == null)
                return false;

            if (clientToUpdate is ProspectIndyvidualClient individualClient)
            {
                individualClient.Forename = request.Forename ?? individualClient.Forename;
                individualClient.Surname = request.Surname ?? individualClient.Surname;
            }
            else
            {
                var companyClient = (ProspectCompanyClient)clientToUpdate;
                companyClient.CompanyName = request.CompanyName ?? companyClient.CompanyName;
                companyClient.Nip = request.Nip ?? companyClient.Nip;
            }

            clientToUpdate.PhoneNumber = request.PhoneNumber ?? clientToUpdate.PhoneNumber;
            clientToUpdate.Email = request.Email ?? clientToUpdate.Email;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProspectClientByIdAsync(int id)
        {
            var clientToRemove = await _context.ProspectClients.FirstOrDefaultAsync(x => x.Id == id);

            if (clientToRemove == null)
                return false;

            clientToRemove.IsRemoved = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
