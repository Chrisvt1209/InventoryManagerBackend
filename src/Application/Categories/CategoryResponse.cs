using Application.Products;

namespace Application.Categories;

public sealed record CategoryResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public ICollection<ProductResponse> Products { get; init; }
}
