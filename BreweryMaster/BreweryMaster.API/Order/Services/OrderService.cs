using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Services;
using BreweryMaster.API.UserModule.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BreweryMaster.API.OrderModule.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public OrderService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<IEnumerable<OrderResponse>> GetOrders(OrderFilterRequest? request = null)
        {
            var response = new List<OrderResponse>();

            if (request is null)
                response = await _context.Orders
                        .Include(x => x.Container)
                        .Include(x => x.Recipe)
                        .Include(x => x.Client)
                        .Include(x => x.CreatedByUser)
                        .Where(x => !x.IsRemoved)
                        .Select(x => new OrderResponse()
                        {
                            Id = x.Id,
                            Capacity = x.Capacity,
                            ContainerId = x.Container.Id,
                            Container = x.Container.ContainerName,
                            Price = x.Price,
                            RecipeId = x.RecipeId,
                            CreatedBy = x.CreatedByUser.ToUserResponse().Name,
                            Recipe = x.Recipe.Name,
                            TargetDate = DateOnly.FromDateTime(x.TargetDate),
                        }).ToListAsync();
            else
            {
                response = await _context.Orders
                        .Include(x => x.Container)
                        .Include(x => x.Recipe)
                        .Include(x => x.Client)
                        .Include(x => x.CreatedByUser)
                        .Where(x => !x.IsRemoved)
                        .Where(x => request.CreatedBy == null || x.CreatedByUserId == request.CreatedBy)
                        .Where(x => request.ExpectedBefore == null || x.TargetDate >= request.ExpectedBefore)
                        .Where(x => request.ExpectedAfter == null || x.TargetDate <= request.ExpectedAfter)
                        .Where(x => request.RecipeName == null || x.Recipe.Name.ToLower().Contains(request.RecipeName.ToLower()))
                        .Select(x => new OrderResponse()
                        {
                            Id = x.Id,
                            Capacity = x.Capacity,
                            ContainerId = x.Container.Id,
                            Container = x.Container.ContainerName,
                            Price = x.Price,
                            RecipeId = x.RecipeId,
                            Recipe = x.Recipe.Name,
                            CreatedBy = x.CreatedByUser.ToUserResponse().Name,
                            TargetDate = DateOnly.FromDateTime(x.TargetDate),
                        }).ToListAsync();
            }


            return response;
        }

        public async Task<IEnumerable<EntityResponse>> GetOrderDropDownList()
        {
            return await _context.Orders
                        .Select(x => new EntityResponse()
                        {
                            Id = x.Id,
                            Name = $"{x.Recipe.Name}, {x.Capacity}, {DateOnly.FromDateTime(x.TargetDate)}",
                        }).ToListAsync();
        }

        public async Task<IEnumerable<OrderResponse>> GetCurrentUserOrders(ClaimsPrincipal? claims)
        {
            var currentUser = await _userService.GetCurrentUser(claims);

            return await _context.Orders
                        .Where(x => x.CreatedByUserId == currentUser.Id)
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
                            TargetDate = DateOnly.FromDateTime(x.TargetDate),
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
                            TargetDate = DateOnly.FromDateTime(x.TargetDate),
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
                                .Include(x => x.OrderStatus)
                                .OrderBy(x => x.ChangedOn).ToListAsync();

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
                StatusId = statusChanges?.LastOrDefault()?.OrderStatusId ?? 1,
                Status = statusChanges?.LastOrDefault()?.OrderStatus.Name ?? "NotSet",
                StatusChanges = statusChanges?.Select(x => new OrderStatusChangeResponse()
                {
                    OrderId = order.Id,
                    OrderStatusId = x.OrderStatusId,
                    OrderStatus = x.OrderStatus.Name,
                    ChangedOnDateOnly = DateOnly.FromDateTime(x.ChangedOn),
                    ChangedOnDateTime = x.ChangedOn,
                })
            };
        }

        public async Task<decimal?> GetOrderPrice(OrderPriceRequest request)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == request.RecipeId);
            var container = await _context.ContainerPrices
                                .Where(x => x.ContainerId == request.ContainerId)
                                .OrderByDescending(x => x.CreatedOn)
                                .Include(x => x.Container)
                                    .ThenInclude(x => x.UnitEntity)
                                .FirstOrDefaultAsync();

            if (recipe is null || container is null)
                return null;

            if (recipe.ExpectedBeerVolume == 0 || container.Container.Capacity == 0)
                throw new DivideByZeroException("ExpectedBeerVolume and Container Capacity can't be zero.");

            var beerPrice = recipe.Price / recipe.ExpectedBeerVolume * request.Capacity;
            var containerPrice = request.Capacity / UnitHelper.ConvertToLitters(container.Container.UnitEntity, container.Container.Capacity) * container.Price;

            return Math.Floor((beerPrice + containerPrice) / 1000) * 1000;
        }

        public async Task<Order?> CreateOrderAsync(OrderRequest request, ClaimsPrincipal? user)
        {
            var currentUser = await _userService.GetCurrentUser(user);

            var price = await GetOrderPrice(new OrderPriceRequest()
            {
                Capacity = request.Capacity,
                ContainerId = request.ContainerId,
                RecipeId = request.RecipeId
            });

            if(price is null)
                return null;

            var clientToCreate = new Order()
            {
                Capacity = request.Capacity,
                ContainerId = request.ContainerId,
                Container = null!,
                Price = (decimal)price,
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
                OrderStatus = orderStatusChangeToCreate.OrderStatus?.Name ?? string.Empty,
                ChangedOnDateTime = orderStatusChangeToCreate.ChangedOn,
                ChangedOnDateOnly = DateOnly.FromDateTime(orderStatusChangeToCreate.ChangedOn),
            };
        }

        public async Task<bool> EditOrderAsync(int id, OrderUpdateRequest request)
        {
            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderToUpdate is null)
                return false;

            orderToUpdate.Capacity = request.Capacity ?? orderToUpdate.Capacity;
            orderToUpdate.ContainerId = request.ContainerId ?? orderToUpdate.ContainerId;
            orderToUpdate.RecipeId = request.RecipeId ?? orderToUpdate.RecipeId;
            orderToUpdate.TargetDate = request.TargetDate ?? orderToUpdate.TargetDate;

            _context.Orders.Update(orderToUpdate);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderToUpdate == null)
                return false;

            orderToUpdate.IsRemoved = true;

            _context.Orders.Update(orderToUpdate);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
