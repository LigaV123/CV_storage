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

            //validations for language
            var duplicateLanguages = cv.LanguageKnowledge
                .Where(l => cv.LanguageKnowledge
                    .Count(ll => ll.Language.ToLowerInvariant() == l.Language.ToLowerInvariant()) > 1).ToList();

            if (duplicateLanguages.Count > 0)
            {
                string languages = Languages(duplicateLanguages);
                string errorMessage = $"{languages}already exists.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            var languageLevelNull = cv.LanguageKnowledge
                .Where(e => e.LanguageLevel == null).ToList();

            if (languageLevelNull.Count > 0)
            {
                string languages = Languages(languageLevelNull);
                string errorMessage = $"Please select level for: {languages.Trim()}.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            //validations for education
            var duplicateEducation = cv.Education
                .Where(e => cv.Education
                    .Count(ee =>
                        ee.EducationalEstablishment.ToLowerInvariant() == e.EducationalEstablishment.ToLowerInvariant()
                        && ee.Faculty.ToLowerInvariant() == e.Faculty.ToLowerInvariant()
                        && ee.Department.ToLowerInvariant() == e.Department.ToLowerInvariant()
                        && ee.Degree == e.Degree) > 1).ToList();

            if (duplicateEducation.Count > 0)
            {
                string educations = Educations(duplicateEducation);
                string errorMessage = $"{educations}already exists.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            var educationDate = cv.Education
                .Where(e =>
                    DateTime.Parse(e.EducationStartDate) > DateTime.Parse(e.EducationEndDate ?? DateTime.Now.Date.ToString())
                ).ToList();

            if (educationDate.Count > 0)
            {
                string educations = Educations(educationDate);
                string errorMessage = $"Education Dates are set incorrectly. " +
                                      $"Make sure that Start date is smaller or the same as the End date for faculty: " +
                                      $"{educations.Trim()}.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            //validations for skills
            var duplicateSkill = cv.GainedSkill
                .Where(s => cv.GainedSkill
                    .Count(ss => 
                        ss.Skill.ToLowerInvariant() == s.Skill.ToLowerInvariant()
                        && ss.SkillDescription == s.SkillDescription) > 1).ToList();

            if (duplicateSkill.Count > 0)
            {
                string skills = Skills(duplicateSkill);
                string errorMessage = $"{skills}already exists.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            var skillTypeNull = cv.GainedSkill
                .Where(s => s.SkillType == null).ToList();

            if (skillTypeNull.Count > 0)
            {
                string skills = Skills(duplicateSkill);
                string errorMessage = $"Please select type for: {skills.Trim()}.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            //validations for jobs
            var duplicateJobs = cv.JobExperience
                .Where(j => cv.JobExperience
                    .Count(jj =>
                        jj.CompanyName.ToLowerInvariant() == j.CompanyName.ToLowerInvariant()
                        && jj.Position.ToLowerInvariant() == j.Position.ToLowerInvariant()) > 1).ToList();

            if (duplicateJobs.Count > 0)
            {
                string jobs = Jobs(duplicateJobs);
                string errorMessage = $"{jobs}already exists.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            var jobsDate = cv.JobExperience
                .Where(e =>
                    DateTime.Parse(e.EmploymentStartDate) > DateTime.Parse(e.EmploymentEndDate ?? DateTime.Now.Date.ToString())
                ).ToList();

            if (jobsDate.Count > 0)
            {
                string jobs = Jobs(jobsDate);
                string errorMessage = $"Employment Dates are set incorrectly. " +
                                      $"Make sure that Start date is smaller or the same as the End date for Position: " +
                                      $"{jobs.Trim()}.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            return true;
        }

        private static string ConcatenateItems<T>(List<T> model, Func<T, string> propertySelector)
        {
            string result = "";
            int lastIndex = model.Count - 1;

            model.ForEach(item =>
            {
                result += propertySelector(item) + (Array.IndexOf(model.ToArray(), item) == lastIndex ? " " : ", ");
            });

            return result;
        }

        private static string Languages(List<LanguageKnowledgeViewModel> model)
        {
            return ConcatenateItems(model, l => l.Language);
        }

        private static string Educations(List<EducationViewModel> model)
        {
            return ConcatenateItems(model, e => e.Faculty);
        }

        private static string Skills(List<GainedSkillViewModel> model)
        {
            return ConcatenateItems(model, s => s.Skill);
        }

        private static string Jobs(List<JobExperienceViewModel> model)
        {
            return ConcatenateItems(model, j => j.Position);
        }
    }
}
