using BreweryMaster.API.OrderModule.Enums;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BreweryMaster.API.OrderModule.Services
{
    public class ProspectOrderService : IProspectOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderSettings _settings;

        public ProspectOrderService(ApplicationDbContext context, IOptions<OrderSettings> options)
        {
            _context = context;
            _settings = options.Value;
        }
        public ProspectOrderDetails GetProspectOrderDetails()
        {
            return new ProspectOrderDetails()
            {
                BeerTypes = Enum.GetValues(typeof(BeerType))
                                .Cast<BeerType>()
                                .Select(x=>new Shared.Models.EntityResponse()
                                {
                                    Id = (int)x + 1,
                                    Name = x.ToString(),
                                }),
                ContainerTypes = Enum.GetValues(typeof(ContainerType))
                                .Cast<ContainerType>()
                                .Select(x => new Shared.Models.EntityResponse()
                                {
                                    Id = (int)x + 1,
                                    Name = x.ToString(),
                                }),
            };
        }
        public decimal GetEstimatedPrice(ProspectPriceEstimationRequest request)
        {
            var beerType = _settings.BeerPrices.FirstOrDefault(x=> (int)x.BeerType + 1 == request.BeerType);
            var containerType = _settings.ContainerPrices.FirstOrDefault(x => (int)x.ContainerType + 1 == request.ContainerType);

            var numberOfContainers = request.Capacity / containerType.Capacity;

            var beerPrice = request.Capacity * beerType.EstimatedPrice;
            var containerPrice = numberOfContainers * containerType.EstimatedPrice;

            return Math.Round((beerPrice + containerPrice)/100,0)*100;
        }

        public async Task<IEnumerable<ProspectOrder>> GetProspectOrdersAsync()
        {
            return await _context.ProspectOrders.ToListAsync();
        }

        public async Task<ProspectOrder?> GetProspectOrderByIdAsync(int id)
        {
            return await _context.ProspectOrders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProspectOrder> CreateProspectOrderAsync(ProspectOrderRequest request)
        {
            var clientToCreate = new ProspectOrder()
            {
                TargetDate = request.TargetDate,
                ProspectClient = null!,
            };

            _context.ProspectOrders.Add(clientToCreate);
            await _context.SaveChangesAsync();

            return clientToCreate;
        }

        public async Task<bool> EditProspectOrderAsync(int id, ProspectOrder order)
        {
            if (id != order.Id)
                return false;

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectOrdersExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> DeleteProspectOrderByIdAsync(int id)
        {
            var order = await _context.ProspectOrders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return false;

            _context.ProspectOrders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProspectOrdersExists(int id)
        {
            return _context.ProspectOrders.Any(x => x.Id == id);
        }
    }
}
