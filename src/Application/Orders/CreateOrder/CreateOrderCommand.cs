using Application.Abstractions.Messaging;

namespace Application.Orders.CreateOrder;

public sealed record CreateOrderCommand(Guid UserId, List<CreateOrderItemDto> OrderItems) : ICommand<Guid>;
