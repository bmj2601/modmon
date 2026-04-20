using MediatR;

namespace Orders.Application;

public record GetOrdersQuery : IRequest<IEnumerable<OrderDto>>;

public record OrderDto(Guid Id, string CustomerName, DateTime OrderDate, decimal TotalAmount);