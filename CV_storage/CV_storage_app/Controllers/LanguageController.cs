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
        private readonly IEntityService<CurriculumVitae> _cvService;
        private readonly IMapper _mapper;

        public LanguageController(
            IEntityService<LanguageKnowledge> languageService,
            IMapper mapper,
            IEntityService<CurriculumVitae> cvService)
        {
            _languageService = languageService;
            _mapper = mapper;
            _cvService = cvService;
        }

        [HttpGet]
        public IActionResult AddLanguageSectionItem(int itemCount, int cvId)
        {
            var model = new CvItemViewModel
            {
                LanguageKnowledge = Enumerable.Repeat(new LanguageKnowledgeViewModel(), itemCount + 1).ToList()
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteLanguageItem(int id, int cvId)
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
