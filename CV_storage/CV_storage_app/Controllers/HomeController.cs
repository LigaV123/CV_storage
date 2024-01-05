using System.ComponentModel;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        public HomeController(ILogger<HomeController> logger, IEntityService<CurriculumVitae> cvService)
        {
            _logger = logger;
            _cvService = cvService;
        }

        public IActionResult Index()
        {
            var cvs = _cvService.Query().Include(cv => cv.LanguageKnowledges).ToList();
            var cvList = new CvListViewModel();
            cvList.CvItems = cvs.Select(cv => new CvItemViewModel()
            {
                Id = cv.Id,
                FirstName = cv.FirstName,
                LastName = cv.LastName,
                Email = cv.Email,
                PhoneNumber = cv.PhoneNumber,
                LanguageKnowledge = cv.LanguageKnowledges.Select(l => new LanguageKnowledgeViewModel
                {
                    CurriculumVitaeId = cv.Id,
                    Id = l.Id,
                    Language = l.Language,
                    LanguageLevel = l.LanguageLevel
                }).ToList()
            }).ToList();

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
                var model = new CvItemViewModel
                {
                    Id = cv.Id,
                    FirstName = cv.FirstName,
                    MiddleName = cv.MiddleName,
                    LastName = cv.LastName,
                    Email = cv.Email,
                    PhoneNumber = cv.PhoneNumber,
                    LanguageKnowledge = cv.LanguageKnowledges.Select(l => new LanguageKnowledgeViewModel
                    {
                        CurriculumVitaeId = cv.Id,
                        Id = l.Id,
                        Language = l.Language,
                        LanguageLevel = l.LanguageLevel
                    }).ToList()
                };

                return View(model);
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CvItemViewModel cv)
        {
            var existingCv = _cvService.QueryById(cv.Id)
                .Include(c => c.LanguageKnowledges).SingleOrDefault();
            if (existingCv != null)
            {
                existingCv.FirstName = cv.FirstName;
                existingCv.MiddleName = cv.MiddleName;
                existingCv.LastName = cv.LastName;
                existingCv.Email = cv.Email;
                existingCv.PhoneNumber = cv.PhoneNumber;

                var existingCvLanguageList = existingCv.LanguageKnowledges.ToList();
                for (var i = 0; i < cv.LanguageKnowledge.Count; i++)
                {
                   existingCvLanguageList[i].Language = cv.LanguageKnowledge[i].Language;
                   existingCvLanguageList[i].LanguageLevel = cv.LanguageKnowledge[i].LanguageLevel;
                }

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CvItemViewModel cv)
        {
            _cvService.Create(new CurriculumVitae
            {
                FirstName = cv.FirstName,
                MiddleName = cv.MiddleName,
                LastName = cv.LastName,
                Email = cv.Email,
                PhoneNumber = cv.PhoneNumber
            });

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