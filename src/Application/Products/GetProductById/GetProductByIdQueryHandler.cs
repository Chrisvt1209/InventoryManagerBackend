using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Products.GetProductById
{
    internal sealed class GetProductByIdQueryHandler(IApplicationDbContext context)
        : IQueryHandler<GetProductByIdQuery, ProductResponse>
    {
        public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            ProductResponse? product = await context.Products
                .Where(p => p.Id == query.ProductId)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryId = p.CategoryId
                })
                .SingleOrDefaultAsync(cancellationToken);

            if (product is null)
            {
                return Result.Failure<ProductResponse>(ProductErrors.NotFound(query.ProductId));
            }

            return product;
        }
    }
}
