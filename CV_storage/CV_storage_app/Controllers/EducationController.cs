using CV_storage.Core.Services;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_storage_app.Controllers
{
    public class EducationController : Controller
    {
        private readonly IDeleteService _deleteService;

        public EducationController(IDeleteService deleteService)
        {
            _deleteService = deleteService;
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
            _deleteService.DeleteEducationById(id);

            return Ok();
        }
    }
}
