using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using MVC_RunGroopWebApp.Data;
using MVC_RunGroopWebApp.Interfaces;
using MVC_RunGroopWebApp.Models;

namespace MVC_RunGroopWebApp.Repository
{
    public class DashBoardRepository : IDashBoardRespository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashBoardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var user = _context.Clubs.Where(r => r.AppUser.Id == curUser);
            return user.ToList();
        }

        public async Task<List<Race>> GetAllUserRaces()
        {
            var userRace = _httpContextAccessor.HttpContext?.User.GetUserId();
            var user = _context.Races.Where(r => r.AppUser.Id == userRace);
            return user.ToList();
        }

        public async Task<AppUser> GetUserById(string Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<AppUser> GetByIdNoTracking(string Id)
        {
            return await _context.Users.Where(r => r.Id == Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0 ? true : false;
        }
    }
}
