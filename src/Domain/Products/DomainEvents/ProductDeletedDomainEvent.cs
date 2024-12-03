using SharedKernel;

namespace Domain.Products.DomainEvents;

public sealed record ProductDeletedDomainEvent(Guid ProductId) : IDomainEvent;
