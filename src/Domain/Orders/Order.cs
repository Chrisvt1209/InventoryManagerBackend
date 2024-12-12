using Domain.Users;
using SharedKernel;

namespace Domain.Orders;

public sealed class Order : Entity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User user { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItem> OrderItems { get; set; } = []; // subject to change to list of order items
}
