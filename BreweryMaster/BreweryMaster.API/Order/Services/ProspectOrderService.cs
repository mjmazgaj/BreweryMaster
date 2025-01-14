using BreweryMaster.API.OrderModule.Enums;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;

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
        public async Task<ProspectOrderDetails> GetProspectOrderDetails()
        {
            var beerStyles = await _context.BeerStyles
                                    .Select(x => new EntityResponse()
                                    {
                                        Id = x.Id,
                                        Name = x.Name
                                    }).ToListAsync();

            var containerTypes = await _context.Containers
                                    .Include(x => x.UnitEntity)
                                    .Select(x => new EntityResponse()
                                    {
                                        Id = x.Id,
                                        Name = $"{x.ContainerName} {x.Capacity}{x.UnitEntity.Name} {x.Material}"
                                    }).ToListAsync();

            return new ProspectOrderDetails()
            {
                BeerTypes = beerStyles,
                ContainerTypes = containerTypes,
            };
        }
        public async Task<decimal> GetEstimatedPrice(ProspectPriceEstimationRequest request)
        {
            var beerType = await _context.BeerPrices
                                .FirstOrDefaultAsync(x=>x.Id ==request.BeerType);
            var containerType = await _context.ContainerPrices
                                .Include(x=>x.Container)
                                    .ThenInclude(x=>x.UnitEntity)
                                .FirstOrDefaultAsync(x => x.Id == request.ContainerType);

            if (beerType is null || containerType is null)
                throw new Exception();

            var containerCapacityInLitters = UnitHelper.ConvertToLitters(containerType!.Container.UnitEntity, containerType!.Container.Capacity);

            var numberOfContainers = request.Capacity / containerCapacityInLitters;

            var beerPrice = (float)(request.Capacity * beerType.Price / 1000);
            var containerPrice = numberOfContainers * (float)containerType.Price;

            return Math.Round(Convert.ToDecimal(beerPrice + containerPrice), 0);
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
            var clientToCreate = new ProspectCompanyClient()
            {
                Id = 1,
                CompanyName = "CompanyName",
                Email = "email@test.pl"
            };

            var prospectToCreate = new ProspectOrder()
            {
                TargetDate = request.TargetDate,
                ProspectClientId = clientToCreate.Id,
                ProspectClient = null!,
                BeerStyleId = request.BeerStyleId,
                BeerStyle = null!,
                ContainerId = request.ContainerId,
                Container = null!,
                Capacity = request.Capacity,
            };

            _context.ProspectOrders.Add(prospectToCreate);
            await _context.SaveChangesAsync();

            return prospectToCreate;
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
