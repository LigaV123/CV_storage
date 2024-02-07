using CV_storage_app.Models;
using FluentValidation;

namespace CV_storage_app.Validators
{
    public class CvItemViewModelValidator : AbstractValidator<CvItemViewModel>
    {
        public CvItemViewModelValidator()
        {
            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 50).WithMessage("Length of {PropertyName} is Invalid ({TotalLength}). Maximal Length is 50 characters.")
                .Must(ValidatorMethods.BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.MiddleName)
                .Length(2, 50)
                .When(p => !string.IsNullOrEmpty(p.MiddleName))
                .WithMessage("Length of {PropertyName} is Invalid ({TotalLength}). Maximal Length is 50 characters.")
                .Must(ValidatorMethods.BeAValidName)
                .When(p => !string.IsNullOrEmpty(p.MiddleName)).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 50).WithMessage("Length of {PropertyName} is Invalid ({TotalLength}). Maximal Length is 50 characters.")
                .Must(ValidatorMethods.BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(5, 50).WithMessage("Length of {PropertyName} is Invalid ({TotalLength}). It should be 5 to 50 characters.")
                .Must(ValidatorMethods.BeAValidEmail).WithMessage("{PropertyName} is Invalid");

            RuleFor(p => p.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(8, 12).WithMessage("Length of {PropertyName} is Invalid ({TotalLength}). It should be 8 to 12 characters.")
                .Must(ValidatorMethods.BeAValidNumber).WithMessage("{PropertyName} is Invalid");

            RuleForEach(e => e.MainAddress).SetValidator(new AddressViewModelValidator());

            RuleForEach(e => e.Education).SetValidator(new EducationViewModelValidator());

            RuleForEach(e => e.GainedSkill).SetValidator(new GainedSkillViewModelValidator());

            RuleForEach(e => e.JobExperience).SetValidator(new JobExperienceViewModelValidator());

            RuleForEach(e => e.LanguageKnowledge).SetValidator(new LanguageKnowledgeViewModelValidator());
        }
    }
}
