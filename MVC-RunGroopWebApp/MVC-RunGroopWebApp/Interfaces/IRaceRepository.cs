using MVC_RunGroopWebApp.Models;

namespace MVC_RunGroopWebApp.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();

        Task<Race> GetByIdAsync(int Id);

        Task<IEnumerable<Race>> GetClubByCity(string city);

        bool Add(Race race);

        bool Update(Race race);

        bool Delete(Race race);

        bool Save();
    }
}
