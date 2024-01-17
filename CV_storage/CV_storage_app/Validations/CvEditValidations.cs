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
                string errorMessage = $"{duplicateLanguages[0].Language} language already exists.";
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
                string errorMessage = "This education already exists.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            var educationDate = cv.Education
                .Where(e => 
                    DateTime.Parse(e.EducationStartDate) > DateTime.Parse(e.EducationEndDate ?? DateTime.Now.Date.ToString())
                ).ToList();

            if (educationDate.Count > 0)
            {
                string errorMessage = "Education Dates are set incorrectly. Make sure that Start date is smaller or the same as the End date.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            var educationFormNull = cv.Education
                .Where(e => e.EducationForm == null).ToList();

            if (educationFormNull.Count > 0)
            {
                string errorMessage = "Form of Education is not set.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            return true;
        }
    }
}
