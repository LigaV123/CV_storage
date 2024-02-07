using CV_storage_app.Models;
using FluentValidation;

namespace CV_storage_app.Validators
{
    public class EducationViewModelValidator : AbstractValidator<EducationViewModel>
    {
        public EducationViewModelValidator()
        {
            RuleFor(p => p.EducationalEstablishment)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 500).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})");

            RuleFor(p => p.Faculty)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 500).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})")
                .Must(ValidatorMethods.BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.Department)
                .Length(2, 500)
                .When(p => !string.IsNullOrEmpty(p.Department)).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})")
                .Must(ValidatorMethods.BeAValidName)
                .When(p => !string.IsNullOrEmpty(p.Department)).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.Degree)
                .IsInEnum().WithMessage("{PropertyName} is Required");

            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("{PropertyName} is Required");

            RuleFor(p => p.EducationStartDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Must(date => ValidatorMethods.BeAValidDate(DateTime.Parse(date))).WithMessage("{PropertyName} is Invalid");

            RuleFor(p => DateTime.Parse(p.EducationEndDate))
                .Must(ValidatorMethods.BeAValidDate)
                .When(p => !string.IsNullOrEmpty(p.EducationEndDate)).WithMessage("{PropertyName} is Invalid")
                .GreaterThanOrEqualTo(p => DateTime.Parse(p.EducationStartDate))
                .When(p => !string.IsNullOrEmpty(p.EducationEndDate))
                .WithMessage("Education End Date must be greater than or equal to Education Start Date");
        }
    }
}
