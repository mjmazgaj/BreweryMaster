using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BreweryMaster.API.OrderModule.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderSettings _settings;

        public OrderService(ApplicationDbContext context, IOptions<OrderSettings> options)
        {
            _context = context;
            _settings = options.Value;
        }

        public async Task<IEnumerable<Models.Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Order> CreateOrderAsync(OrderRequest request)
        {
            var clientToCreate = new Order()
            {
                TargetDate = request.TargetDate
            };

            _context.Orders.Add(clientToCreate);
            await _context.SaveChangesAsync();

            return clientToCreate;
        }

        public async Task<bool> EditOrderAsync(int id, Order order)
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
