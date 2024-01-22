using MVC_RunGroopWebApp.Models;

namespace MVC_RunGroopWebApp.Interfaces
{
    public interface IDashBoardRespository
    {
        Task<List<Club>> GetAllUserClubs();

        Task<List<Race>> GetAllUserRaces();

        Task<AppUser> GetUserById(string Id);

        Task<AppUser> GetByIdNoTracking(string Id);
         bool Update(AppUser user);
         bool Save();
        
    }
}
