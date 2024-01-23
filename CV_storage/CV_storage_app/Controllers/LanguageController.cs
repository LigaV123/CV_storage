using System.Collections;
using AutoMapper;
using CV_storage.Core.Models;
using CV_storage.Core.Services;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_storage_app.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IEntityService<LanguageKnowledge> _languageService;

        public LanguageController(IEntityService<LanguageKnowledge> languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public IActionResult AddLanguageSectionItem(int itemCount)
        {
            var model = new CvItemViewModel
            {
                LanguageKnowledge = Enumerable.Repeat(new LanguageKnowledgeViewModel(), itemCount + 1).ToList()
            };

            //var language = model.LanguageKnowledge[^1];
            //_languageService.Create(new LanguageKnowledge
            //{
            //    Id = language.Id,
            //    CurriculumVitaeId = language.CurriculumVitaeId,
            //    Language = language.Language,
            //    LanguageLevel = language.LanguageLevel
            //});

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteLanguageItem(int id)
        {
            var language = _languageService.GetById(id);

            if (language != null)
            {
                _languageService.Delete(language);
            }

            return Ok();
        }
    }
}
