using BreweryMaster.API.OrderModule.Models;

public interface IOrderService
{
    decimal GetPrice(PriceEstimationRequest request);
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(OrderRequest rder);
    Task<bool> EditOrderAsync(int id, Order order);
    Task<bool> DeleteOrderByIdAsync(int id);
}