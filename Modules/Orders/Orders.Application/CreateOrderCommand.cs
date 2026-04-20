using MediatR;

namespace Orders.Application;

public record CreateOrderCommand(string CustomerName, decimal TotalAmount) : IRequest<Guid>;
