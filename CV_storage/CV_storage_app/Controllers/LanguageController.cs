using CV_storage.Core.Services;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_storage_app.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IDeleteService _deleteService;

        public LanguageController(IDeleteService deleteService)
        {
            _deleteService = deleteService;
        }

        [HttpGet]
        public IActionResult AddLanguageSectionItem(int itemCount)
        {
            var model = new CvItemViewModel
            {
                LanguageKnowledge = Enumerable.Repeat(new LanguageKnowledgeViewModel(), itemCount + 1).ToList()
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteLanguageItem(int id)
        {
            _deleteService.DeleteLanguageById(id);

            return Ok();
        }
    }
}
