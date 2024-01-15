using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CV_storage_app
{
    public class CvEditValidations : ICvValidations
    {
        public bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return false;
            }

            var duplicateLanguages = cv.LanguageKnowledge
                .Where(l => cv.LanguageKnowledge
                    .Count(ll => ll.Language.ToLowerInvariant() == l.Language.ToLowerInvariant()) > 1).ToList();

            if (duplicateLanguages.Count > 0)
            {
                string errorMessage = $"{duplicateLanguages[0].Language} language already exists.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            return true;
        }
    }
}
