using BreweryMaster.API.OrderModule.Helpers;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.OrderModules.Models;
using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.OrderModule.Services
{
    public class ProspectOrderService : IProspectOrderService
    {
        private readonly IProspectClientService _prospectClientService;
        private readonly ApplicationDbContext _context;

        public ProspectOrderService(ApplicationDbContext context, IProspectClientService prospectClientService)
        {
            _context = context;
            _prospectClientService = prospectClientService;
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
                                .FirstOrDefaultAsync(x => x.Id == request.BeerType);
            var containerType = await _context.ContainerPrices
                                .Include(x => x.Container)
                                    .ThenInclude(x => x.UnitEntity)
                                .FirstOrDefaultAsync(x => x.Id == request.ContainerType);

            if (beerType is null || containerType is null)
                throw new ArgumentNullException($"{nameof(containerType)} and {nameof(beerType)} can not be null");

            var containerCapacityInLitters = UnitHelper.ConvertToLitters(containerType!.Container.UnitEntity, containerType!.Container.Capacity);

            var numberOfContainers = request.Capacity / containerCapacityInLitters;

            var beerPrice = request.Capacity * beerType.Price / 1000;
            var containerPrice = numberOfContainers * containerType.Price;

            return Math.Round(beerPrice + containerPrice, 0);
        }

        public async Task<IEnumerable<ProspectOrderResponse>> GetProspectOrdersAsync(ProspectOrderFilterRequest? request)
        {
            var response = new List<ProspectOrderResponse>();

            if (request is null)
                response = await _context.ProspectOrders
                                 .Where(x => !x.IsRemoved)
                                .Include(x => x.BeerStyle)
                                .Include(x => x.ProspectClient)
                                .Include(x => x.Container)
                                .Select(x => new ProspectOrderResponse()
                                {
                                    Id = x.Id,
                                    BeerStyle = x.BeerStyle.Name,
                                    BeerStyleId = x.BeerStyleId,
                                    Capacity = x.Capacity,
                                    Container = x.Container.ContainerName,
                                    ContainerTypeId = x.ContainerId,
                                    ClientName = x.ProspectClient.GetName(),
                                    Email = x.ProspectClient.Email,
                                    PhoneNumber = x.ProspectClient.PhoneNumber,
                                    TargetDate = DateOnly.FromDateTime(x.TargetDate),
                                    IsClosed = x.IsClosed,
                                }).ToListAsync();
            else
            {
                response = await _context.ProspectOrders
                                 .Where(x => !x.IsRemoved)
                                .Include(x => x.BeerStyle)
                                .Include(x => x.ProspectClient)
                                .Include(x => x.Container)
                                .Where(x => request.ClientId == null || x.ProspectClientId == request.ClientId)
                                .Where(x => request.ExpectedBefore == null || x.TargetDate <= request.ExpectedBefore)
                                .Where(x => request.ExpectedAfter == null || x.TargetDate >= request.ExpectedAfter)
                                .Where(x => request.BeerStyleId == null || x.BeerStyleId == request.BeerStyleId)
                                .Select(x => new ProspectOrderResponse()
                                {
                                    Id = x.Id,
                                    BeerStyle = x.BeerStyle.Name,
                                    BeerStyleId = x.BeerStyleId,
                                    Capacity = x.Capacity,
                                    Container = x.Container.ContainerName,
                                    ContainerTypeId = x.ContainerId,
                                    ClientName = x.ProspectClient.GetName(),
                                    Email = x.ProspectClient.Email,
                                    PhoneNumber = x.ProspectClient.PhoneNumber,
                                    TargetDate = DateOnly.FromDateTime(x.TargetDate),
                                    IsClosed = x.IsClosed,
                                }).ToListAsync();
            }

            return response;
        }

        public async Task<ProspectOrder?> GetProspectOrderByIdAsync(int id)
        {
            return await _context.ProspectOrders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProspectOrder?> CreateProspectOrderAsync(ProspectOrderRequest request)
        {
            var client = await _prospectClientService.CreateProspectClientAsync(request.Client);

            if (client is null)
                throw new Exception("client can not be null");

            var orderToCreate = new ProspectOrder()
            {
                TargetDate = request.TargetDate,
                ProspectClientId = client.Id,
                ProspectClient = null!,
                BeerStyleId = request.BeerStyleId,
                BeerStyle = null!,
                ContainerId = request.ContainerId,
                Container = null!,
                Capacity = request.Capacity,
                CreatedOn = DateTime.Now,
            };

            _context.ProspectOrders.Add(orderToCreate);
            await _context.SaveChangesAsync();

            return await GetProspectOrderByIdAsync(orderToCreate.Id);
        }

        public async Task<bool> EditProspectOrderAsync(int id, ProspectOrderUpdateRequest request)
        {
            var orderToUpdate = await _context.ProspectOrders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderToUpdate == null)
                return false;

            orderToUpdate.BeerStyleId = request.BeerStyleId ?? orderToUpdate.BeerStyleId;
            orderToUpdate.ContainerId = request.ContainerId ?? orderToUpdate.ContainerId;
            orderToUpdate.Capacity = request.Capacity ?? orderToUpdate.Capacity;
            orderToUpdate.TargetDate = request.TargetDate ?? orderToUpdate.TargetDate;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProspectOrderByIdAsync(int id)
        {
            var orderToRemove = await _context.ProspectOrders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderToRemove == null)
                return false;

            orderToRemove.IsRemoved = true;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
