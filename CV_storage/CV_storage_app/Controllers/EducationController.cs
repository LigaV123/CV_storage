using CV_storage.Core.Models;
using CV_storage.Core.Services;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_storage_app.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEntityService<Education> _educationService;

        public EducationController(IEntityService<Education> educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public IActionResult AddEducationSectionItem(int itemCount)
        {
            var model = new CvItemViewModel
            {
                Education = Enumerable.Repeat(new EducationViewModel(), itemCount + 1).ToList()
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteEducationItem(int id)
        {
            if (id > 0)
            {
                _educationService.DeleteById(id);
            }

            return Ok();
        }
    }
}
