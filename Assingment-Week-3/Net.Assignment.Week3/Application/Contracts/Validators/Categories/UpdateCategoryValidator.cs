using Application.Contracts.Requests.Categories;
using FluentValidation;
using static Application.Contracts.Messages.CategoryMessages;

namespace Application.Contracts.Validators.Categories;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x=>x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(CategoryNameIsRequired)
            .MaximumLength(30)
            .WithMessage(CategoryNameMustBeLessThan30Characters);

        RuleFor(x => x.Order)
            .NotNull()
            .NotEmpty()
            .WithMessage(CategoryOrderIsRequired);
    }
}