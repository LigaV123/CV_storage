using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CV_storage_app
{
    public interface ICvValidations
    {
        bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState);
    }
}
