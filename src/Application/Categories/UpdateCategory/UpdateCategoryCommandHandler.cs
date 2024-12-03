using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using SharedKernel;

namespace Application.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(IApplicationDbContext context)
    : ICommandHandler<UpdateCategoryCommand>
{
    public async Task<Result> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FindAsync(command.Id);

        if (category is null)
        {
            return Result.Failure(CategoryErrors.NotFound(command.Id));
        }

        category.Name = command.Name;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(category);
    }
}
