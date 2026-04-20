using Orders.Application;

namespace Orders.Api;

public interface IOrdersService
{
    Task<Guid> CreateOrderAsync(string customerName, decimal totalAmount);
    Task<IEnumerable<Orders.Application.OrderDto>> GetOrdersAsync();
}