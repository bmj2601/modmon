namespace Orders.Domain;

public class Order
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; } = null!;
    public DateTime OrderDate { get; private set; }
    public decimal TotalAmount { get; private set; }

    private Order() { } // EF Core

    public Order(string customerName, decimal totalAmount)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("Customer name is required", nameof(customerName));

        Id = Guid.NewGuid();
        CustomerName = customerName;
        OrderDate = DateTime.UtcNow;
        TotalAmount = totalAmount;
    }
}
