using Domain.Categories.DomainEvents;
using MediatR;

namespace Application.Categories.CreateCategory;

internal sealed class CreatedCategoryDomainEventHandler : INotificationHandler<CategoryCreatedDomainEvent>
{
    public Task Handle(CategoryCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        // Send notification that category is created
        return Task.CompletedTask;
    }
}
