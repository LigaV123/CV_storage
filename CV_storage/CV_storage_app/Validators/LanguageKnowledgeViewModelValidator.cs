using CV_storage_app.Models;
using FluentValidation;

namespace CV_storage_app.Validators
{
    public class LanguageKnowledgeViewModelValidator : AbstractValidator<LanguageKnowledgeViewModel>
    {
        public LanguageKnowledgeViewModelValidator()
        {
            RuleFor(p => p.Language)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .Length(2, 30).WithMessage("Length of {PropertyName} is Invalid ({TotalLength})")
                .Must(ValidatorMethods.BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(p => p.LanguageLevel)
                .IsInEnum().WithMessage("{PropertyName} is Required");
        }
    }
}
