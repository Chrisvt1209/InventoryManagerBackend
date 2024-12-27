using Application.Abstractions.Messaging;

namespace Application.Products.GetAllProducts;

public sealed record GetAllProductsQuery() : IQuery<List<ProductResponse>>;