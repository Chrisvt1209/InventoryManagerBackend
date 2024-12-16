namespace Application.Orders.CreateOrder;

public sealed record CreateOrderItemDto(Guid ProductId, int Quantity);
