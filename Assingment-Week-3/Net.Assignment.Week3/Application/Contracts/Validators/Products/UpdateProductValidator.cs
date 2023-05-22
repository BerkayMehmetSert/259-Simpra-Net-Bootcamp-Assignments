using Application.Contracts.Messages;
using Application.Contracts.Requests.Products;
using FluentValidation;

namespace Application.Contracts.Validators.Products;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProductMessages.ProductNameIsRequired)
            .MaximumLength(30)
            .WithMessage(ProductMessages.ProductNameMustBeLessThan30Characters);
        
        RuleFor(x => x.Url)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProductMessages.ProductUrlIsRequired)
            .MaximumLength(30)
            .WithMessage(ProductMessages.ProductUrlMustBeLessThan30Characters);
        
        RuleFor(x => x.Tag)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProductMessages.ProductTagIsRequired)
            .MaximumLength(100)
            .WithMessage(ProductMessages.ProductTagMustBeLessThan100Characters);
    }
}