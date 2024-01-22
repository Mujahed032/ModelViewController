using Institute_WebApi.Models;

namespace Institute_WebApi.Interface
{
    public interface IFacultyRepository
    {
        Task<Faculty> GetFacultyById(int facultyId);
        Task<IEnumerable<Faculty>> GetAllFacultys();
        Task<Faculty> AddFaculty(Faculty faculty);
        Task<Faculty> UpdateFaculty(Faculty faculty);
        Task<bool> DeleteFaculty(int facultyId);
    }
}
