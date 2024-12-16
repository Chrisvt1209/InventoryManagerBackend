﻿using Domain.Users;
using SharedKernel;

namespace Domain.Orders;

public sealed class Order : Entity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TotalAmount { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
    public OrderStatus OrderStatus { get; set; }
}
