using Application.Requests;
using FluentValidation;
using static Application.Constants.StaffMessage;

namespace Application.FluentValidations.Staff
{
    public class UpdateStaffValidator : AbstractValidator<UpdateStaffRequest>
    {
        public UpdateStaffValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage(FirstNameRequired)
                .MaximumLength(30)
                .WithMessage(FirstNameMaxLength);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(LastNameRequired)
                .MaximumLength(30)
                .WithMessage(LastNameMaxLength);

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage(EmailInvalid)
                .NotEmpty()
                .WithMessage(EmailRequired)
                .MaximumLength(50)
                .WithMessage(EmailMaxLength);

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage(PhoneRequired)
                .MaximumLength(30)
                .WithMessage(PhoneMaxLength);

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage(DateOfBirthRequired);

            RuleFor(x => x.AddressLine1)
                .NotEmpty()
                .WithMessage(AddressLine1Required)
                .MaximumLength(150)
                .WithMessage(AddressLine1MaxLength);

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage(CityRequired)
                .MaximumLength(50)
                .WithMessage(CityMaxLength);

            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage(CountryRequired)
                .MaximumLength(100)
                .WithMessage(CountryMaxLength);

            RuleFor(x => x.Province)
                .NotEmpty()
                .WithMessage(ProvinceRequired)
                .MaximumLength(50)
                .WithMessage(ProvinceMaxLength);
        }
    }
}
