using Application.Abstractions.Messaging;

namespace Application.Products.CreateProduct;

public sealed record CreateProductCommand(string Name, string Description, decimal Price, int Quantity, Guid CategoryId)
    : ICommand<Guid>;
