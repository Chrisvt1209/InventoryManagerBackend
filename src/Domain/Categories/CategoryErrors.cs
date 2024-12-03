using SharedKernel;

namespace Domain.Categories;

public static class CategoryErrors
{
    public static Error NotFound(Guid categoryId)
    {
        return Error.NotFound("Categories.NotFound", $"The category with id '{categoryId}' was not found.");
    }

    public static readonly Error NameNotUnique = Error.Conflict("Categories.NameNotUnique", "The provided name is already in use.");
}
