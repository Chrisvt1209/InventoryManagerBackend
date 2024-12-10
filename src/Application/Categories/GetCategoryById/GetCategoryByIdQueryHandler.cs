using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Products;
using Domain.Categories;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Categories.GetCategoryById;

internal sealed class GetCategoryByIdQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>
{
    public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        CategoryResponse? category = await context.Categories
            .Where(c => c.Id == query.CategoryId)
            .Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
                Products = c.Products.Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryId = p.CategoryId
                }).ToList()
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (category is null)
        {
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound(query.CategoryId));
        }

        return category;
    }
}
