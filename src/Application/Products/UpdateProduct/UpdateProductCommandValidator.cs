using FluentValidation;

namespace Application.Products.UpdateProduct
{
    internal sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
