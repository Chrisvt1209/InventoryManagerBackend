using SharedKernel;

namespace Domain.Products;

public static class ProductErrors
{
    public static Error NotFound(Guid productId)
    {
        return Error.NotFound("Products.NotFound", $"The product with id '{productId}' was not found.");
    }

    public static readonly Error NameNotUnique = Error.Conflict("Products.NameNotUnique", "The provided name is already in use.");

    public static readonly Error InvalidPrice = Error.Failure("Products.InvalidPrice", "The price must be greater than zero.");

    public static readonly Error InvalidQuantity = Error.Failure("Products.InvalidStock", "The stock must be greater than or equal to zero.");
}
