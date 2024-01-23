using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CV_storage_app.Validations
{
    public class CvEditValidations : ICvValidations
    {
        public bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return false;
            }

            //lists for language view model validation
            var duplicateLanguages = cv.LanguageKnowledge
                .Where(l => cv.LanguageKnowledge
                    .Count(ll => ll.Language.ToLowerInvariant() == l.Language.ToLowerInvariant()) > 1).ToList();

            var languageLevelNull = cv.LanguageKnowledge
                .Where(e => e.LanguageLevel == null).ToList();

            //lists for education view model validation
            var duplicateEducation = cv.Education
                .Where(e => cv.Education
                    .Count(ee =>
                        ee.EducationalEstablishment.ToLowerInvariant() == e.EducationalEstablishment.ToLowerInvariant()
                        && ee.Faculty.ToLowerInvariant() == e.Faculty.ToLowerInvariant()
                        && ee.Department.ToLowerInvariant() == e.Department.ToLowerInvariant()
                        && ee.Degree == e.Degree) > 1).ToList();

            var educationDate = cv.Education
                .Where(e =>
                    DateTime.Parse(e.EducationStartDate) > DateTime.Parse(e.EducationEndDate ?? DateTime.Now.Date.ToString())
                ).ToList();

            //lists for skill view model validation
            var duplicateSkill = cv.GainedSkill
                .Where(s => cv.GainedSkill
                    .Count(ss => 
                        ss.Skill.ToLowerInvariant() == s.Skill.ToLowerInvariant()
                        && ss.SkillDescription == s.SkillDescription) > 1).ToList();

            var skillTypeNull = cv.GainedSkill
                .Where(s => s.SkillType == null).ToList();

            //lists for job view model validation
            var duplicateJobs = cv.JobExperience
                .Where(j => cv.JobExperience
                    .Count(jj =>
                        jj.CompanyName.ToLowerInvariant() == j.CompanyName.ToLowerInvariant()
                        && jj.Position.ToLowerInvariant() == j.Position.ToLowerInvariant()) > 1).ToList();

            var jobsDate = cv.JobExperience
                .Where(e =>
                    DateTime.Parse(e.EmploymentStartDate) > DateTime.Parse(e.EmploymentEndDate ?? DateTime.Now.Date.ToString())
                ).ToList();

            //actual validation
            //duplicate item validation
            if (!CvModelListValidationMethods.DuplicateListIsEmpty(duplicateLanguages, CvItemFormattingMethods.Languages, modelState)
                || !CvModelListValidationMethods.DuplicateListIsEmpty(duplicateEducation, CvItemFormattingMethods.Educations, modelState)
                || !CvModelListValidationMethods.DuplicateListIsEmpty(duplicateSkill, CvItemFormattingMethods.Skills, modelState)
                || !CvModelListValidationMethods.DuplicateListIsEmpty(duplicateJobs, CvItemFormattingMethods.Jobs, modelState))
            {
                return false;
            }

            //enum value validation
            if (!CvModelListValidationMethods.EnumListIsEmpty(languageLevelNull, CvItemFormattingMethods.Languages, modelState) 
                || !CvModelListValidationMethods.EnumListIsEmpty(skillTypeNull, CvItemFormattingMethods.Skills, modelState))
            {
                return false;
            }

            //date validation
            if (!CvModelListValidationMethods.DateListIsEmpty(jobsDate, CvItemFormattingMethods.Jobs, modelState) 
                || !CvModelListValidationMethods.DateListIsEmpty(educationDate, CvItemFormattingMethods.Educations, modelState))
            {
                return false;
            }

            return true;
        }
    }
}
