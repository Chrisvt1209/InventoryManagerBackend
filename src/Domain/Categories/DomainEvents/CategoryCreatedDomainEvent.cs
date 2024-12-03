using SharedKernel;

namespace Domain.Categories.DomainEvents;

public sealed record CategoryCreatedDomainEvent(Guid CategoryId) : IDomainEvent;
