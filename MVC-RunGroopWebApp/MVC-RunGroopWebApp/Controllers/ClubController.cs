﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_RunGroopWebApp.Data;
using MVC_RunGroopWebApp.Interfaces;
using MVC_RunGroopWebApp.Models;

namespace MVC_RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {

        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
           
            _clubRepository = clubRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

       
        public async Task<IActionResult> Detail(int Id)
        {
            Club club = await _clubRepository.GetByIdAsync(Id);
            return View(club);
        }

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if(!ModelState.IsValid)
            {
                return View(club);
            }
            _clubRepository.Add(club);
            return RedirectToAction("Index");
        }
    }
}
