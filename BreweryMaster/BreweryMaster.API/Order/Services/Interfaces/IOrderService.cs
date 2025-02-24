using BreweryMaster.API.Info.Models;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models;
using System.Security.Claims;

public interface IOrderService
{
    Task<IEnumerable<OrderResponse>> GetOrders(OrderFilterRequest? request);
    Task<IEnumerable<EntityResponse>> GetOrderDropDownList();
    Task<IEnumerable<OrderResponse>> GetCurrentUserOrders(ClaimsPrincipal claims);
    Task<IEnumerable<EntityResponse>> GetOrderStatuses();
    Task<OrderResponse?> GetOrderByIdAsync(int id);
    Task<OrderDetailsResponse?> GetOrderDetailById(int id);
    Task<decimal> GetOrderPrice(OrderPriceRequest request);
    Task<Order> CreateOrderAsync(OrderRequest request, ClaimsPrincipal? user);
    Task<OrderStatusChangeResponse> CreateOrderStatusChange(OrderStatusChangeRequest request);
    Task<bool> EditOrderAsync(int id, OrderUpdateRequest request);
    Task<bool> DeleteOrderByIdAsync(int id);
}