using MVC_RunGroopWebApp.Models;

namespace MVC_RunGroopWebApp.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAppUsers();

        Task<AppUser> GetUserById(string id);
        bool Add(AppUser user);
        bool Update(AppUser user);
        bool Delete(AppUser user);

        bool Save();
    }
}
