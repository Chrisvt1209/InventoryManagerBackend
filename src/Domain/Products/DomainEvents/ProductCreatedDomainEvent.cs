using SharedKernel;

namespace Domain.Products.DomainEvents;

public sealed record ProductCreatedDomainEvent(Guid ProductId) : IDomainEvent;
