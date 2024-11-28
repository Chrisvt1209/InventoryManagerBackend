using SharedKernel;

namespace Domain.Products;

public static class ProductErrors
{
    public static Error NotFound(Guid productId)
    {
        return Error.NotFound("Products.NotFound", $"The product with id '{productId}' was not found.");
    }

    public static readonly Error NameNotUnique = Error.Conflict("Products.NameNotUnique", "The provided name is already in use.");
}
