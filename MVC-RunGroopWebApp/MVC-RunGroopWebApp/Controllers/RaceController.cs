﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_RunGroopWebApp.Data;
using MVC_RunGroopWebApp.Interfaces;
using MVC_RunGroopWebApp.Models;
using MVC_RunGroopWebApp.ViewModels;
using System.Reflection;

namespace MVC_RunGroopWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RaceController(IRaceRepository raceRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _raceRepository = raceRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
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
            var curUserId = _httpContextAccessor.HttpContext.User?.GetUserId();
            var raceViewModel = new CreateRaceViewModel { AppUserId = curUserId };
            return View(raceViewModel);
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
        public async Task<IActionResult> Edit(int Id)
        {
            var race = await _raceRepository.GetByIdAsync(Id);
            if (race == null) return View("Eroor");

            var raceVM = new EditRaceViewModel
            {
                Title = race.Title,
                Description = race.Description,
                AddressId = race.AddressId,
                Address = race.Address,
                URL = race.Image,
                RaceCategory = race.RaceCategory

            };
            return View(raceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,EditRaceViewModel raceVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit the race");
            };
            var userRace = await _raceRepository.GetByIdAsyncNoTracking(id);
            if(userRace!=null)
            {
                try
                {
                   await _photoService.DeletePhotoAsync(userRace.Image);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Failed to delete the photo");
                    return View(raceVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(raceVM.Image);
                var race = new Race
                {
                    Id = id,
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    AddressId = raceVM.AddressId,
                    Address = raceVM.Address,
                    Image = photoResult.Url.ToString()
                };
                _raceRepository.Update(race);
                return RedirectToAction("index");
            }
            else
            {
                return View(raceVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var raceDetails = await _raceRepository.GetByIdAsync(id);
            if (raceDetails == null) return View("Error");
            return View(raceDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var raceDetails = await _raceRepository.GetByIdAsync(id);
                if (raceDetails == null) return View("Eroor");

            _raceRepository.Delete(raceDetails);

            return RedirectToAction("Index");
        }
    }
}
