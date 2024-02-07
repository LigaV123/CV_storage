using CV_storage_app.Models;
using FluentValidation;

namespace CV_storage_app.Validators
{
    public class AddressViewModelValidator : AbstractValidator<AddressViewModel>
    {
        public AddressViewModelValidator()
        {
            RuleFor(p => p.Country)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 1024).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})")
                .Must(ValidatorMethods.BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.City)
                .Length(2, 1024)
                .When(p => !string.IsNullOrEmpty(p.City)).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})")
                .Must(ValidatorMethods.BeAValidName)
                .When(p => !string.IsNullOrEmpty(p.City)).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.Region)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 1024).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})")
                .Must(ValidatorMethods.BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.StreetAddress)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 2048).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})");

            RuleFor(p => p.PostalCode)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 1024).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})");
        }
    }
}
