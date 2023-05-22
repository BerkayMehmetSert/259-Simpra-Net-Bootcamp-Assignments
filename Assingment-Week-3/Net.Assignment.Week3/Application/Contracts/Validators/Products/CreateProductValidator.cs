using Application.Contracts.Requests.Products;
using FluentValidation;
using static Application.Contracts.Messages.ProductMessages;

namespace Application.Contracts.Validators.Products;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProductCategoryIdIsRequired);

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProductNameIsRequired)
            .MaximumLength(30)
            .WithMessage(ProductNameMustBeLessThan30Characters);

        RuleFor(x => x.Url)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProductUrlIsRequired)
            .MaximumLength(30)
            .WithMessage(ProductUrlMustBeLessThan30Characters);

        RuleFor(x => x.Tag)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProductTagIsRequired)
            .MaximumLength(100)
            .WithMessage(ProductTagMustBeLessThan100Characters);
    }

}