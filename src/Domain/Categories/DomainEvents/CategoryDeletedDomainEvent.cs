using SharedKernel;

namespace Domain.Categories.DomainEvents;

public sealed record CategoryDeletedDomainEvent() : IDomainEvent;