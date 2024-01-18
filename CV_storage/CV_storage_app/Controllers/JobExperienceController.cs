using CV_storage.Core.Models;
using CV_storage.Core.Services;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_storage_app.Controllers
{
    public class JobExperienceController : Controller
    {
        private readonly IEntityService<JobExperience> _jobService;

        public JobExperienceController(IEntityService<JobExperience> jobService)
        {
            _jobService = jobService;
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
            var job = _jobService.GetById(id);

            if (job != null)
            {
                _jobService.Delete(job);
            }

            return Ok();
        }
    }
}
