using CV_storage_app.Models;
using CV_storage_app.ValidationExtentions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CV_storage_app.Validations
{
    public class CvEnumValueValidation : ICvValidations
    {
        public bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState)
        {
            var languageLevelNull = cv.LanguageKnowledge
                .Where(e => e.LanguageLevel == null).ToList();

            var skillTypeNull = cv.GainedSkill
                .Where(s => s.SkillType == null).ToList();

            if (!CvModelListValidation.EnumListIsEmpty(languageLevelNull, CvItemFormatting.Languages, modelState)
                || !CvModelListValidation.EnumListIsEmpty(skillTypeNull, CvItemFormatting.Skills, modelState))
            {
                return false;
            }

            return true;
        }
    }
}
