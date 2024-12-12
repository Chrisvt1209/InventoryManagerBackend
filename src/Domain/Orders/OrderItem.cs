using Domain.Products;
using SharedKernel;

namespace Domain.Orders;

public sealed class OrderItem : Entity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Order order { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
