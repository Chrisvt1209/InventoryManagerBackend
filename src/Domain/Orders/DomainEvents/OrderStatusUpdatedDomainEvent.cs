using SharedKernel;

namespace Domain.Orders.DomainEvents;

public sealed record OrderStatusUpdatedDomainEvent(Guid OrderId) : IDomainEvent;
