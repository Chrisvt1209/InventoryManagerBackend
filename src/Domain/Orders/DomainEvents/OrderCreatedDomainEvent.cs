using SharedKernel;

namespace Domain.Orders.DomainEvents;

public sealed record OrderCreatedDomainEvent(Guid OrderId) : IDomainEvent;
