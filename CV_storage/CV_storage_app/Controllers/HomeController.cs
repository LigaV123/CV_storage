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
        private readonly IEntityService<CurriculumVitae> _cvService;
        private readonly IMapper _mapper;
        private readonly ICvValidations _validations;
        private readonly IDeleteService _deleteService;

        public HomeController( 
            IEntityService<CurriculumVitae> cvService,
            IMapper mapper,
            ICvValidations validations,
            IDeleteService deleteService)
        {
            _cvService = cvService;
            _mapper = mapper;
            _validations = validations;
            _deleteService = deleteService;
        }

        public IActionResult Index()
        {
            var cvs = _cvService.Query().ToList();

            var cvList = new CvListViewModel
            {
                CvItems = cvs.Select(_mapper.Map<CvItemViewModel>).ToList()
            };

            return View(cvList);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _deleteService.DeleteCvById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cv = GetDetailedCvById(id);

            if (cv != null)
            {
                if (cv.MainAddress.Count == 0)
                {
                    cv.MainAddress.Add(new Address());
                }

                if(cv.AdditionalInformation.Count == 0)
                {
                    cv.AdditionalInformation.Add(new AdditionalInformation());
                }

                return View(_mapper.Map<CvItemViewModel>(cv));
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CvItemViewModel cv)
        {
            if (!ModelState.IsValid || !_validations.IsValid(cv, ModelState))
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
            var cv = new CurriculumVitae();
            cv.MainAddress.Add(new Address());
            cv.AdditionalInformation.Add(new AdditionalInformation());

            return View(_mapper.Map<CvItemViewModel>(cv));
        }

        [HttpPost]
        public IActionResult Create(CvItemViewModel cv)
        {
            if (!ModelState.IsValid || !_validations.IsValid(cv, ModelState))
            {
                return View(cv);
            }

            _cvService.Create(_mapper.Map<CurriculumVitae>(cv));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Print(int id)
        {
            var cv = GetDetailedCvById(id);

            return View(_mapper.Map<CvItemViewModel>(cv));
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

        private CurriculumVitae? GetDetailedCvById(int id)
        {
            return _cvService.QueryById(id)
                .Include(cv => cv.LanguageKnowledge)
                .Include(cv => cv.Education)
                .Include(cv => cv.MainAddress)
                .Include(cv => cv.JobExperience)
                .Include(cv => cv.GainedSkill)
                .Include(cv => cv.AdditionalInformation)
                .SingleOrDefault();
        }
    }
}