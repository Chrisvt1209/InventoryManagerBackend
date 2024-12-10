using Domain.Products;
using SharedKernel;

namespace Domain.Orders;

public sealed class Order : Entity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public List<Product> Products { get; set; } // subject to change to list of order items
}
