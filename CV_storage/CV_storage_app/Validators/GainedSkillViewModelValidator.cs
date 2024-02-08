using CV_storage_app.Models;
using FluentValidation;

namespace CV_storage_app.Validators
{
    public class GainedSkillViewModelValidator : AbstractValidator<GainedSkillViewModel>
    {
        public GainedSkillViewModelValidator()
        {
            RuleFor(p => p.Skill)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 150).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})")
                .Must(ValidatorMethods.BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.SkillType)
                .IsInEnum().WithMessage("{PropertyName} is Required");
        }
    }
}
