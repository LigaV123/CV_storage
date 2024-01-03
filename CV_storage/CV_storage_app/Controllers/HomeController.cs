using System.ComponentModel;
using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CV_storage.Core.Models;
using CV_storage.Core.Services;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

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
            var cvs = _cvService.Get();
            var cvList = new CvListViewModel();
            cvList.CvItems = cvs.Select(cv => new CvItemViewModel()
            {
                Id = cv.Id,
                FirstName = cv.FirstName,
                LastName = cv.LastName,
                Email = cv.Email,
                PhoneNumber = cv.PhoneNumber
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
            var cv = _cvService.GetById(id);
            if (cv != null)
            {
                var model = new CvItemViewModel
                {
                    Id = cv.Id,
                    FirstName = cv.FirstName,
                    MiddleName = cv.MiddleName,
                    LastName = cv.LastName,
                    Email = cv.Email,
                    PhoneNumber = cv.PhoneNumber
                };

                return View(model);
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CvItemViewModel cv)
        {
            var existingCv = _cvService.GetById(cv.Id);
            if (existingCv != null)
            {
                existingCv.FirstName = cv.FirstName;
                existingCv.MiddleName = cv.MiddleName;
                existingCv.LastName = cv.LastName;
                existingCv.Email = cv.Email;
                existingCv.PhoneNumber = cv.PhoneNumber;

                _cvService.Update(existingCv);
            }

            return RedirectToAction("Index");
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