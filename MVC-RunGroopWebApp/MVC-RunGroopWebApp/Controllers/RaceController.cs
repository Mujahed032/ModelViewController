﻿using Microsoft.AspNetCore.Mvc;
using MVC_RunGroopWebApp.Data;
using MVC_RunGroopWebApp.Models;

namespace MVC_RunGroopWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Race> Races = _context.Races.ToList();
            return View(Races);
        }
    }
}