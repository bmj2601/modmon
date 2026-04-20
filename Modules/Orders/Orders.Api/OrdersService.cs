using MediatR;
using Orders.Application;

namespace Orders.Api;

public class OrdersService : IOrdersService
{
    private readonly IMediator _mediator;

    public OrdersService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Guid> CreateOrderAsync(string customerName, decimal totalAmount)
    {
        return await _mediator.Send(new CreateOrderCommand(customerName, totalAmount));
    }

    public async Task<IEnumerable<Orders.Application.OrderDto>> GetOrdersAsync()
    {
        return await _mediator.Send(new GetOrdersQuery());
    }
}