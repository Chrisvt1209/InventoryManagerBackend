using Application.Abstractions.Messaging;
using Domain.Orders;

namespace Application.Orders.CreateOrder;

public sealed record CreateOrderCommand(Guid UserId, List<OrderItem> Items) : ICommand<Guid>;
