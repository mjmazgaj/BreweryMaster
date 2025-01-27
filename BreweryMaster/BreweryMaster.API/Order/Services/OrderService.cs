using BreweryMaster.API.OrderModule.Models;
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
                        .Include(x => x.User)
                        .Select(x => new OrderResponse()
                        {
                            Id = x.Id,
                            Capacity = x.Capacity,
                            UserId = x.UserId,
                            User = x.User.UserName,
                            ContainerId = x.Container.Id,
                            Container = x.Container.ContainerName,
                            Price = x.Price,
                            RecipeId = x.RecipeId,
                            Recipe = x.Recipe.Name,
                            TargetDate = x.TargetDate,
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
                            UserId = x.UserId,
                            User = x.User.UserName,
                            ContainerId = x.Container.Id,
                            Container = x.Container.ContainerName,
                            Price = x.Price,
                            RecipeId = x.RecipeId,
                            Recipe = x.Recipe.Name,
                            TargetDate = x.TargetDate,
                        }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> CreateOrderAsync(OrderRequest request, ClaimsPrincipal? user)
        {
            var currentUser = await _userService.GetCurrentUser(user);

            var clientToCreate = new Order()
            {
                UserId = currentUser.Id,
                User = null!,
                Capacity = request.Capacity,
                ContainerId = request.ContainerId,
                Container = null!,
                Price = request.Price,
                RecipeId = request.RecipeId,
                Recipe = null!,
                TargetDate = request.TargetDate,
            };

            _context.Orders.Add(clientToCreate);
            await _context.SaveChangesAsync();

            return clientToCreate;
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
