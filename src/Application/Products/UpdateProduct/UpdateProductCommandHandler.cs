using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler(IApplicationDbContext context)
    : ICommandHandler<UpdateProductCommand>
{
    public async Task<Result> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        Product? product = await context.Products
            .SingleOrDefaultAsync(p => p.Id == command.Id, cancellationToken);

        if (product is null)
        {
            return Result.Failure(ProductErrors.NotFound(command.Id));
        }

        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;
        product.Quantity = command.Quantity;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(product);
    }
}