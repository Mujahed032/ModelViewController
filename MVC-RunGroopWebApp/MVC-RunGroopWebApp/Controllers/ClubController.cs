using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_RunGroopWebApp.Data;
using MVC_RunGroopWebApp.Models;

namespace MVC_RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }

       
        public IActionResult Detail(int Id)
        {
            Club club = _context.Clubs.Include(a => a.Address).FirstOrDefault(x => x.Id == Id);
            return View(club);
        }
    }
}
