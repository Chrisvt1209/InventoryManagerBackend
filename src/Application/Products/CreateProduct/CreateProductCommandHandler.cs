using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Products;
using Domain.Products.DomainEvents;
using SharedKernel;

namespace Application.Products.CreateProduct;

internal sealed class CreateProductCommandHandler(IApplicationDbContext context)
    : ICommandHandler<CreateProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            Quantity = command.Quantity,
            CategoryId = command.CategoryId
        };
        product.Raise(new ProductCreatedDomainEvent(product.Id));

        context.Products.Add(product);

        await context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
