using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CV_storage_app.Validations
{
    public class CvModelListValidationMethods
    {
        public static bool DuplicateListIsEmpty<T>(List<T> model, Func<List<T>, string> methodName, ModelStateDictionary modelState)
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

        public static bool EnumListIsEmpty<T>(List<T> model, Func<List<T>, string> methodName, ModelStateDictionary modelState)
        {
            if (model.Count > 0)
            {
                string concatenatedItems = methodName(model);
                string word = methodName.Method.Name == "Skills" ? "type" : "level";
                string errorMessage = $"Please select {word} for: {concatenatedItems}.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            return true;
        }

        public static bool DateListIsEmpty<T>(List<T> model, Func<List<T>, string> methodName, ModelStateDictionary modelState)
        {
            if (model.Count > 0)
            {
                string concatenatedItems = methodName(model);
                string modelName = methodName.Method.ToString() == "Jobs" ? "Employment" : "Education";
                string itemName = methodName.Method.ToString() == "Jobs" ? "Position" : "Faculty";
                string errorMessage = $"{modelName} Dates are set incorrectly. " +
                                      $"Make sure that Start date is smaller or the same as the End date for {itemName}: " +
                                      $"{concatenatedItems}.";
                modelState.AddModelError("error", errorMessage);

                return false;
            }

            return true;
        }

        
    }
}
