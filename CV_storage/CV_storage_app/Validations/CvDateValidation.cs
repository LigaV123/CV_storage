using CV_storage_app.Models;
using CV_storage_app.ValidationExtentions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CV_storage_app.Validations
{
    public class CvDateValidation : ICvValidations
    {
        public bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState)
        {
            var educationDate = cv.Education
                .Where(e =>
                    DateTime.Parse(e.EducationStartDate) > DateTime.Parse(e.EducationEndDate ?? DateTime.Now.Date.ToString())
                ).ToList();

            var jobsDate = cv.JobExperience
                .Where(e =>
                    DateTime.Parse(e.EmploymentStartDate) > DateTime.Parse(e.EmploymentEndDate ?? DateTime.Now.Date.ToString())
                ).ToList();

            if (!CvModelListValidation.DateListIsEmpty(jobsDate, CvItemFormatting.Jobs, modelState)
                || !CvModelListValidation.DateListIsEmpty(educationDate, CvItemFormatting.Educations, modelState))
            {
                return false;
            }

            return true;
        }
    }
}
