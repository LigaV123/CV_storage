using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace CV_storage_app.Validations
{
    public class CvPhoneNumberValidation : ICvValidations
    {
        public bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState)
        {
            string number = cv.PhoneNumber.Trim();

            foreach (var c in number)
            {
                if (char.IsLetter(c) || c == '+' && number.LastIndexOf(c) != 0)
                {
                    string errorMessage = $"Please make sure there are no Letters in phone number " +
                                          $"and (if you use) symbol + is only set before the digits.";
                    modelState.AddModelError("error", errorMessage);

                    return false;
                }
            }

            return true;
        }
    }
}
