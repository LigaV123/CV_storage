using CV_storage_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using CV_storage.Core.Models;
using CV_storage.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CV_storage_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<CurriculumVitae> _cvService;
        private readonly IMapper _mapper;
        private readonly ICvValidations _validations;

        public HomeController(ILogger<HomeController> logger, 
            IEntityService<CurriculumVitae> cvService,
            IMapper mapper,
            ICvValidations validations)
        {
            _logger = logger;
            _cvService = cvService;
            _mapper = mapper;
            _validations =validations;
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
            if (!_validations.IsValid(cv, ModelState))
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