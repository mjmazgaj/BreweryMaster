using BreweryMaster.API.Order.Models.ProspectOrder;
using BreweryMaster.API.Order.Models.Settings;
using BreweryMaster.API.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BreweryMaster.API.Order.Services
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
                BeerTypes = Enum.GetNames(typeof(BeerType)),
                ContainerTypes = Enum.GetNames(typeof(ContainerType))
            };
        }
        public decimal GetEstimatedPrice(PriceEstimationRequest request)
        {
            var beerType = _settings.BeerPrices.FirstOrDefault(x=> x.BeerType.ToString() == request.BeerType);
            var containerType = _settings.ContainerPrices.FirstOrDefault(x => x.ContainerType.ToString() == request.ContainerType);

            var numberOfContainers = request.Capacity / containerType.Capacity;

            var beerPrice = request.Capacity * beerType.EstimatedPrice;
            var containerPrice = numberOfContainers * containerType.EstimatedPrice;

            return Math.Round((beerPrice + containerPrice)/100,0)*100;
        }

        public async Task<IEnumerable<ProspectOrder>> GetProspectOrdersAsync()
        {
            return await _context.ProspectOrders.ToListAsync();
        }

        public async Task<ProspectOrder> GetProspectOrderByIdAsync(int id)
        {
            return await _context.ProspectOrders.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<ProspectOrder> CreateProspectOrderAsync(ProspectOrderRequest request)
        {
            var clientToCreate = new ProspectOrder()
            {
                OrderCompletionDate = request.OrderCompletionDate
            };

            _context.ProspectOrders.Add(clientToCreate);
            await _context.SaveChangesAsync();

            return clientToCreate;
        }

        public async Task<bool> EditProspectOrderAsync(int id, ProspectOrder order)
        {
            if (id != order.ID)
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
            var order = await _context.ProspectOrders.FirstOrDefaultAsync(x => x.ID == id);

            if (order == null)
                return false;

            _context.ProspectOrders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProspectOrdersExists(int id)
        {
            return _context.ProspectOrders.Any(x => x.ID == id);
        }
    }
}
