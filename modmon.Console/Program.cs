using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orders.Api;
using Orders.Infrastructure;
using Shared.Database;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // For demo purposes, using InMemory. In production, pass context.Configuration
        services.AddDatabase();
        services.AddOrdersModule();
    })
    .Build();

using var scope = host.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
await context.Database.EnsureCreatedAsync();

var ordersService = scope.ServiceProvider.GetRequiredService<IOrdersService>();

// Create an order
var orderId = await ordersService.CreateOrderAsync("John Doe", 100.50m);
Console.WriteLine($"Created order with ID: {orderId}");

// List all orders
var orders = await ordersService.GetOrdersAsync();
Console.WriteLine("All orders:");
foreach (var order in orders)
{
    Console.WriteLine($"ID: {order.Id}, Customer: {order.CustomerName}, Date: {order.OrderDate}, Amount: {order.TotalAmount}");
}
