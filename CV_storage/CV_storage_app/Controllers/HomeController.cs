using System.ComponentModel;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using CV_storage.Core.Models;
using CV_storage.Core.Services;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace CV_storage_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<CurriculumVitae> _cvService;
        private readonly IEntityService<LanguageKnowledge> _languageService;
        private readonly IMapper _mapper;
        private readonly CvEditValidations _validations;

        public HomeController(ILogger<HomeController> logger, 
            IEntityService<CurriculumVitae> cvService, 
            IEntityService<LanguageKnowledge> languageService, 
            IMapper mapper, 
            CvEditValidations editValidations)
        {
            _logger = logger;
            _cvService = cvService;
            _languageService = languageService;
            _mapper = mapper;
            _validations = editValidations;
        }

        public IActionResult Index()
        {
            var cvs = _cvService.Query().Include(cv => cv.LanguageKnowledges).ToList();
            var cvList = new CvListViewModel
            {
                CvItems = cvs.Select(_mapper.Map<CvItemViewModel>).ToList()
            };

            return View(cvList);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cv = _cvService.GetById(id);
            if (cv != null)
            {
                _cvService.Delete(cv);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cv = _cvService.QueryById(id)
                .Include(cv => cv.LanguageKnowledges).SingleOrDefault();
            if (cv != null)
            {
                return View(_mapper.Map<CvItemViewModel>(cv));
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CvItemViewModel cv)
        {
            if (_validations.IsValid(cv, ModelState))
            {
                return View(cv);
            }

            var existingCv = _cvService.GetById(cv.Id);

            if (existingCv != null)
            {
                _mapper.Map(cv, existingCv);
                _cvService.Update(existingCv);
            }

            return RedirectToAction("Index");
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
            var language = _languageService.GetById(id);
           
            if (language != null)
            {
                _languageService.Delete(language);
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CvItemViewModel cv)
        {
            _cvService.Create(_mapper.Map<CurriculumVitae>(cv));

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}