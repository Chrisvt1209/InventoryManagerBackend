using Application.Abstractions.Messaging;

namespace Application.Products.UpdateProduct;

public sealed record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, int Quantity) : ICommand;
