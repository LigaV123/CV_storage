using CV_storage.Core.Models;
using CV_storage.Core.Services;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_storage_app.Controllers
{
    public class GainedSkillController : Controller
    {
        private readonly IEntityService<GainedSkill> _skillService;

        public GainedSkillController(IEntityService<GainedSkill> skillService)
        {
            _skillService = skillService;
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
            if (id > 0)
            {
                _skillService.DeleteById(id);
            }

            return Ok();
        }
    }
}
