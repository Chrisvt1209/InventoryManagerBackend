using Domain.Products.DomainEvents;
using MediatR;

namespace Application.Products.CreateProduct;

internal sealed class CreatedProductDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
{
    public Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        // Send notification that product is created
        return Task.CompletedTask;
    }
}
