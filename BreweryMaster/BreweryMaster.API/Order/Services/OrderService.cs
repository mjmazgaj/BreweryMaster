using BreweryMaster.API.Info.Models;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace BreweryMaster.API.OrderModule.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<OrderSettings> options;
        private readonly IUserService _userService;
        private readonly OrderSettings _settings;

        public OrderService(ApplicationDbContext context, IOptions<OrderSettings> options, IUserService userService)
        {
            _context = context;
            this.options = options;
            _userService = userService;
            _settings = options.Value;
        }

        public async Task<IEnumerable<OrderResponse>> GetOrdersAsync()
        {
            return await _context.Orders
                        .Include(x => x.Container)
                        .Include(x => x.Recipe)
                        .Include(x => x.Client)
                        .Include(x => x.CreatedByUser)
                        .Select(x => new OrderResponse()
                        {
                            Id = x.Id,
                            Capacity = x.Capacity,
                            ContainerId = x.Container.Id,
                            Container = x.Container.ContainerName,
                            Price = x.Price,
                            RecipeId = x.RecipeId,
                            Recipe = x.Recipe.Name,
                            TargetDate = x.TargetDate,
                        }).ToListAsync();
        }

        public async Task<IEnumerable<EntityResponse>> GetOrderStatuses()
        {
            return await _context.OrderStatuses
                            .Select(x => new EntityResponse()
                            {
                                Id = x.Id,
                                Name = x.Name,
                            }).ToListAsync();
        }

        public async Task<OrderResponse?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                        .Include(x => x.Container)
                        .Select(x => new OrderResponse()
                        {
                            Id = x.Id,
                            Capacity = x.Capacity,
                            ContainerId = x.Container.Id,
                            Container = x.Container.ContainerName,
                            Price = x.Price,
                            RecipeId = x.RecipeId,
                            Recipe = x.Recipe.Name,
                            TargetDate = x.TargetDate,
                        }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderDetailsResponse?> GetOrderDetailById(int id)
        {
            var order = await _context.Orders
                            .Include(x => x.Container)
                            .Include(x => x.Recipe)
                                .ThenInclude(x => x.Type)
                            .Include(x => x.Recipe)
                                .ThenInclude(x => x.Style)
                            .Include(x => x.CreatedByUser)
                            .FirstOrDefaultAsync(x => x.Id == id);

            if (order is null)
                return null;

            var statusChanges = await _context.OrderStatusChanges
                                .Where(x => x.OrderId == id)
                                .Include(x=>x.OrderStatus)
                                .OrderBy(x=>x.ChangedOn).ToListAsync();

            return new OrderDetailsResponse()
            {
                Id = order.Id,
                Capacity = order.Capacity,
                Container = order.Container.ContainerName,
                ContainerId = order.ContainerId,
                CreatedBy = order.CreatedByUser.Email,
                Price = order.Price,
                Recipe = new RecipeResponse()
                {
                    Id = order.Recipe.Id,
                    Name = order.Recipe.Name,
                    ABVScale = order.Recipe.ABVScale,
                    BLGScale = order.Recipe.BLGScale,
                    IBUScale = order.Recipe.IBUScale,
                    SRMScale = order.Recipe.SRMScale,
                    StyleId = order.Recipe.StyleId,
                    StyleName = order.Recipe.Style?.Name,
                    TypeId = order.Recipe.TypeId,
                    TypeName = order.Recipe.Type?.Name,
                },
                TargetDate = DateOnly.FromDateTime(order.TargetDate),
                CreatedOn = DateOnly.FromDateTime(order.CreatedOn),
                StatusId = statusChanges.LastOrDefault()?.OrderStatusId ?? 1,
                Status = statusChanges.LastOrDefault()?.OrderStatus.Name ?? "NotSet",
                StatusChanges = statusChanges.Select(x=>new OrderStatusChangeResponse()
                {
                    OrderId = order.Id,
                    OrderStatusId = x.OrderStatusId,
                    OrderStatus = x.OrderStatus.Name,
                    ChangedOnDateOnly = DateOnly.FromDateTime(x.ChangedOn),
                    ChangedOnDateTime = x.ChangedOn,
                })
            };
        }

        public async Task<Order> CreateOrderAsync(OrderRequest request, ClaimsPrincipal? user)
        {
            var currentUser = await _userService.GetCurrentUser(user);

            var clientToCreate = new Order()
            {
                ClientId = null,
                Client = null,
                Capacity = request.Capacity,
                ContainerId = request.ContainerId,
                Container = null!,
                Price = request.Price,
                RecipeId = request.RecipeId,
                Recipe = null!,
                TargetDate = request.TargetDate,
                CreatedOn = DateTime.Now,
                CreatedByUser = null!,
                CreatedByUserId = currentUser.Id,
            };

            _context.Orders.Add(clientToCreate);
            await _context.SaveChangesAsync();

            return clientToCreate;
        }

        public async Task<OrderStatusChangeResponse> CreateOrderStatusChange(OrderStatusChangeRequest request)
        {
            var orderStatusChangeToCreate = new OrderStatusChange()
            {
                OrderId = request.OrderId,
                Order = null!,
                OrderStatusId = request.OrderStatusId,
                OrderStatus = null!,
                ChangedOn = DateTime.Now,
            };

            _context.OrderStatusChanges.Add(orderStatusChangeToCreate);
            await _context.SaveChangesAsync();

            return new OrderStatusChangeResponse()
            {
                OrderId = orderStatusChangeToCreate.OrderId,
                OrderStatusId = orderStatusChangeToCreate.OrderStatusId,
                OrderStatus = orderStatusChangeToCreate.OrderStatus?.Name ?? "",
                ChangedOnDateTime = orderStatusChangeToCreate.ChangedOn,
                ChangedOnDateOnly = DateOnly.FromDateTime(orderStatusChangeToCreate.ChangedOn),
            };
        }

        public async Task<bool> EditOrderAsync(int id, OrderUpdateRequest order)
        {
            if (order.Id != id)
                return false;

            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderToUpdate is null)
                throw new Exception();

            orderToUpdate.Capacity = order.Capacity;
            orderToUpdate.ContainerId = order.ContainerId;
            orderToUpdate.Price = order.Price;
            orderToUpdate.RecipeId = order.RecipeId;
            orderToUpdate.TargetDate = order.TargetDate;

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(x => x.Id == id);
        }
    }
}
