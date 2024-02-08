using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CV_storage_app.Validators
{
    public class DuplicateItemValidation : ICvValidations
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

            if (!IsDuplicateListEmpty(duplicateLanguages, Languages, modelState)
                || !IsDuplicateListEmpty(duplicateEducation, Educations, modelState)
                || !IsDuplicateListEmpty(duplicateSkill, Skills, modelState)
                || !IsDuplicateListEmpty(duplicateJobs, Jobs, modelState))
            {
                return false;
            }

            return true;
        }

        private bool IsDuplicateListEmpty<T>(List<T> model, Func<List<T>, string> methodName, ModelStateDictionary modelState)
        {
            if (model.Count > 0)
            {
                string concatenatedItems = methodName(model);
                string errorMessage = $"{concatenatedItems} already exists.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            return true;
        }

        private string Languages(List<LanguageKnowledgeViewModel> model)
        {
            return ConcatenateItems(model, l => l.Language);
        }

        private string Educations(List<EducationViewModel> model)
        {
            return ConcatenateItems(model, e => e.Faculty);
        }

        private string Skills(List<GainedSkillViewModel> model)
        {
            return ConcatenateItems(model, s => s.Skill);
        }

        private string Jobs(List<JobExperienceViewModel> model)
        {
            return ConcatenateItems(model, j => j.Position);
        }

        private string ConcatenateItems<T>(List<T> model, Func<T, string> propertySelector)
        {
            var distinctValues = model.Select(propertySelector).Distinct().ToList();
            string result = string.Join(", ", distinctValues);

            return result;
        }
    }
}
