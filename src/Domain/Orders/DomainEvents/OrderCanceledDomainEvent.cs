using SharedKernel;

namespace Domain.Orders.DomainEvents;

public sealed record OrderCanceledDomainEvent() : IDomainEvent;
