using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Orders.Api;
using Orders.Application;
using Orders.Infrastructure;

namespace Orders.Infrastructure;

public static class OrdersServiceCollectionExtensions
{
    public static IServiceCollection AddOrdersModule(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly));
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrdersService, OrdersService>();

        return services;
    }
}