using Application.Abstractions.Messaging;

namespace Application.Products.UpdateProduct;

public sealed record UpdateProductCommand(Guid Id) : ICommand;
