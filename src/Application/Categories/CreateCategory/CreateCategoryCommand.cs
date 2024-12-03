using Application.Abstractions.Messaging;
using Domain.Products;

namespace Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name, ICollection<Product> Products) : ICommand<Guid>;
