using Application.Abstractions.Messaging;
using Domain.Products;

namespace Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid Id, string Name, ICollection<Product> Products) : ICommand;