using Application.Abstractions.Messaging;

namespace Application.Products.GetProductById
{
    public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductResponse>;
}
