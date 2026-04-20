using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orders.Api;
using Orders.Infrastructure;
using Shared.Database;

namespace modmon.Tests;

public class OrdersModuleTests
{
    [Fact]
    public async Task TestCreateOrder()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddDatabase();
        services.AddOrdersModule();

        var provider = services.BuildServiceProvider();
        var ordersService = provider.GetRequiredService<IOrdersService>();

        var orderId = await ordersService.CreateOrderAsync("Test Customer", 50.00m);

        Assert.NotEqual(Guid.Empty, orderId);

        var orders = await ordersService.GetOrdersAsync();
        Assert.Single(orders);
        Assert.Equal("Test Customer", orders.First().CustomerName);
        Assert.Equal(50.00m, orders.First().TotalAmount);
    }
}
