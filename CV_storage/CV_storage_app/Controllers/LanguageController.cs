﻿using CV_storage.Core.Models;
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

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteLanguageItem(int id)
        {
            if (id > 0)
            {
                _languageService.DeleteById(id);
            }

            return Ok();
        }
    }
}
