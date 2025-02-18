using BreweryMaster.API.Info.Models;
using BreweryMaster.API.OrderModule.Models;
using System.Security.Claims;

public interface IOrderService
{
    Task<IEnumerable<OrderResponse>> GetOrdersAsync();
    Task<IEnumerable<EntityResponse>> GetOrderStatuses();
    Task<OrderResponse?> GetOrderByIdAsync(int id);
    Task<OrderDetailsResponse?> GetOrderDetailById(int id);
    Task<Order> CreateOrderAsync(OrderRequest request, ClaimsPrincipal? user);
    Task<OrderStatusChangeResponse> CreateOrderStatusChange(OrderStatusChangeRequest request);
    Task<bool> EditOrderAsync(int id, OrderUpdateRequest request);
    Task<bool> DeleteOrderByIdAsync(int id);
}