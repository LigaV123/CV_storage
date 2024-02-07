using CV_storage.Core.Services;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_storage_app.Controllers
{
    public class JobExperienceController : Controller
    {
        private readonly IDeleteService _deleteService;

        public JobExperienceController(IDeleteService deleteService)
        {
            _deleteService = deleteService;
        }

        [HttpGet]
        public IActionResult AddJobExperienceSectionItem(int itemCount)
        {
            var model = new CvItemViewModel
            {
                JobExperience = Enumerable.Repeat(new JobExperienceViewModel(), itemCount + 1).ToList()
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteJobExperienceItem(int id)
        {
            _deleteService.DeleteJobById(id);

            return Ok();
        }
    }
}
