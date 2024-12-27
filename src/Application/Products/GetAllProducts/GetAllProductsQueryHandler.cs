using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Products.GetAllProducts;

internal sealed class GetAllProductsQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetAllProductsQuery, List<ProductResponse>>
{
    public async Task<Result<List<ProductResponse>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        IQueryable<Product> productsQuery = context.Products;

        var products = await productsQuery
            .Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryId = p.CategoryId
            })
            .ToListAsync(cancellationToken);

        return products;
    }
}
