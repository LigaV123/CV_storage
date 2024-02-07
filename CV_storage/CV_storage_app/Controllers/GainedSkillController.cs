using CV_storage.Core.Services;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_storage_app.Controllers
{
    public class GainedSkillController : Controller
    {
        private readonly IDeleteService _deleteService;

        public GainedSkillController(IDeleteService deleteService)
        {
            _deleteService = deleteService;
        }

        [HttpGet]
        public IActionResult AddGainedSkillSectionItem(int itemCount)
        {
            var model = new CvItemViewModel
            {
                GainedSkill = Enumerable.Repeat(new GainedSkillViewModel(), itemCount + 1).ToList()
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteGainedSkillItem(int id)
        {
            _deleteService.DeleteSkillById(id);

            return Ok();
        }
    }
}
