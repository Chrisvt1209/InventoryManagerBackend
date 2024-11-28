using FluentValidation;

namespace Application.Products.DeleteProduct;

internal sealed class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p => p.ProductId).NotEmpty();
    }
}
