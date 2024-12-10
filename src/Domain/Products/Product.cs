using SharedKernel;

namespace Domain.Products;

public sealed class Product : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
}
