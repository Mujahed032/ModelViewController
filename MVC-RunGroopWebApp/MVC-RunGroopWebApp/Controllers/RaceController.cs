using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_RunGroopWebApp.Data;
using MVC_RunGroopWebApp.Interfaces;
using MVC_RunGroopWebApp.Models;
using MVC_RunGroopWebApp.ViewModels;

namespace MVC_RunGroopWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;

        public RaceController(IRaceRepository raceRepository, IPhotoService photoService)
        {
            _raceRepository = raceRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> Races = await _raceRepository.GetAll();
            return View(Races);
        }

        public async Task<IActionResult> Detail(int Id)
        {
            Race race = await _raceRepository.GetByIdAsync(Id);
            return View(race);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel raceVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(raceVM.Image);

                  var race = new Race

                {
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = raceVM.Address.Street,
                        City = raceVM.Address.City,
                        State = raceVM.Address.State
                    }
                };
                _raceRepository.Add(race);
                return RedirectToAction("Index");

            }
           else
             {
                ModelState.AddModelError("", "photo upload failed");
            }
            return View(raceVM);
           
        }
    }
}
