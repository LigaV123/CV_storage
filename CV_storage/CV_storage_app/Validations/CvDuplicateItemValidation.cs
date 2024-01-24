using CV_storage_app.Models;
using CV_storage_app.ValidationExtentions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CV_storage_app.Validations
{
    public class CvDuplicateItemValidation : ICvValidations
    {
        public bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState)
        {
            var duplicateLanguages = cv.LanguageKnowledge
                .Where(l => cv.LanguageKnowledge
                    .Count(ll => ll.Language.ToLowerInvariant() == l.Language.ToLowerInvariant()) > 1).ToList();

            var duplicateEducation = cv.Education
                .Where(e => cv.Education
                    .Count(ee =>
                        ee.EducationalEstablishment.ToLowerInvariant() == e.EducationalEstablishment.ToLowerInvariant()
                        && ee.Faculty.ToLowerInvariant() == e.Faculty.ToLowerInvariant()
                        && ee.Department.ToLowerInvariant() == e.Department.ToLowerInvariant()
                        && ee.Degree == e.Degree) > 1).ToList();

            var duplicateSkill = cv.GainedSkill
                .Where(s => cv.GainedSkill
                    .Count(ss =>
                        ss.Skill.ToLowerInvariant() == s.Skill.ToLowerInvariant()
                        && ss.SkillDescription == s.SkillDescription) > 1).ToList();

            var duplicateJobs = cv.JobExperience
                .Where(j => cv.JobExperience
                    .Count(jj =>
                        jj.CompanyName.ToLowerInvariant() == j.CompanyName.ToLowerInvariant()
                        && jj.Position.ToLowerInvariant() == j.Position.ToLowerInvariant()) > 1).ToList();

            if (!CvModelListValidation.DuplicateListIsEmpty(duplicateLanguages, CvItemFormatting.Languages, modelState)
                || !CvModelListValidation.DuplicateListIsEmpty(duplicateEducation, CvItemFormatting.Educations, modelState)
                || !CvModelListValidation.DuplicateListIsEmpty(duplicateSkill, CvItemFormatting.Skills, modelState)
                || !CvModelListValidation.DuplicateListIsEmpty(duplicateJobs, CvItemFormatting.Jobs, modelState))
            {
                return false;
            }

            return true;
        }
    }
}
