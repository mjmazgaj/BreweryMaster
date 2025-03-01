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
            if (request.IsCompany)
                return await CreateProspectCompanyClient(request);
            else
                return await CreateProspectIndividualClient(request);
        }

        private async Task<ProspectClient> CreateProspectCompanyClient(ProspectClientRequest request)
        {
            if (request.CompanyClient is null)
                throw new ArgumentNullException($"{typeof(ProspectClientCompanyRequest)} can not be null");

            var clientToCreate = new ProspectCompanyClient()
            {
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                CompanyName = request.CompanyClient.CompanyName,
                Nip = request.CompanyClient.Nip,
                CreatedOn = DateTime.Now,
            };
            _context.ProspectClients.Add(clientToCreate);


            await _context.SaveChangesAsync();

            return clientToCreate;
        }

        private async Task<ProspectClient> CreateProspectIndividualClient(ProspectClientRequest request)
        {
            if (request.IndividualClient is null)
                throw new ArgumentNullException($"{typeof(ProspectClientIndividualRequest)} can not be null");

            var clientToCreate = new ProspectIndyvidualClient()
            {
                Forename = request.IndividualClient.Forename,
                Surname = request.IndividualClient.Surname,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                CreatedOn = DateTime.Now,
            };

            _context.ProspectClients.Add(clientToCreate);

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
