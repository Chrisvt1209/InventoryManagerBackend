using SharedKernel;

namespace Domain.Categories.DomainEvents;

public sealed record CategoryUpdatedDomainEvent(Guid CategoryId) : IDomainEvent;