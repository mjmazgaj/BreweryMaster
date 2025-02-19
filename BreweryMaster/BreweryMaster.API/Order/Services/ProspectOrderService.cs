﻿using BreweryMaster.API.Info.Models;
using BreweryMaster.API.OrderModule.Helpers;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.Shared.Models;
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

            var beerPrice = request.Capacity * beerType.Price / 1000;
            var containerPrice = numberOfContainers * containerType.Price;

            return Math.Round(beerPrice + containerPrice, 0);
        }

        public async Task<IEnumerable<ProspectOrderResponse>> GetProspectOrdersAsync()
        {
            return await _context.ProspectOrders
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
        }

        public async Task<ProspectOrder?> GetProspectOrderByIdAsync(int id)
        {
            return await _context.ProspectOrders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProspectOrder?> CreateProspectOrderAsync(ProspectOrderRequest request)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {

                ProspectClient clientToCreate = null!;

                if (request.IsCompany && !string.IsNullOrEmpty(request.CompanyName))
                {
                    clientToCreate = new ProspectCompanyClient()
                    {
                        CompanyName = request.CompanyName,
                        Email = "email@test.pl",
                        Nip = request.NIP,
                        Orders = null!,
                        PhoneNumber = request.PhoneNumber,
                        CreatedOn = DateTime.Now,
                    };

                    _context.ProspectClients.Add(clientToCreate);
                    await _context.SaveChangesAsync();
                }
                else if (!string.IsNullOrEmpty(request.Forename) && !string.IsNullOrEmpty(request.Surname))
                {
                    clientToCreate = new ProspectIndyvidualClient()
                    {
                        Forename = request.Forename,
                        Surname = request.Surname,
                        Email = "email@test.pl",
                        Orders = null!,
                        PhoneNumber = request.PhoneNumber,
                        CreatedOn = DateTime.Now,
                    };

                    _context.ProspectClients.Add(clientToCreate);
                    await _context.SaveChangesAsync();
                }

                if (clientToCreate is null)
                    throw new Exception("ClientToCreate can not be null");

                var orderToCreate = new ProspectOrder()
                {
                    TargetDate = request.TargetDate,
                    ProspectClientId = clientToCreate.Id,
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

                await transaction.CommitAsync();

                return await GetProspectOrderByIdAsync(orderToCreate.Id);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
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
