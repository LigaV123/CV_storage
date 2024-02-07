using CV_storage_app.Models;
using FluentValidation;

namespace CV_storage_app.Validators
{
    public class JobExperienceViewModelValidator : AbstractValidator<JobExperienceViewModel>
    {
        public JobExperienceViewModelValidator()
        {
            RuleFor(p => p.CompanyName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 500).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})");

            RuleFor(p => p.Position)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 500).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})")
                .Must(ValidatorMethods.BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.JobDescription)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(10, 1875).WithMessage("Length of {PropertyName} is Invalid ({TotalLength}). It should be 10 to 1875 characters.");

            RuleFor(p => p.EmploymentStartDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Must(date => ValidatorMethods.BeAValidDate(DateTime.Parse(date))).WithMessage("{PropertyName} is Invalid");

            RuleFor(p => DateTime.Parse(p.EmploymentEndDate))
                .Must(ValidatorMethods.BeAValidDate)
                .When(p => !string.IsNullOrEmpty(p.EmploymentEndDate)).WithMessage("{PropertyName} is Invalid")
                .GreaterThanOrEqualTo(p => DateTime.Parse(p.EmploymentStartDate))
                .When(p => !string.IsNullOrEmpty(p.EmploymentEndDate))
                .WithMessage("{PropertyName} must be greater than or equal to Education Start Date");
        }
    }
}
