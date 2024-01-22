using Institute_WebApi.Data;
using Institute_WebApi.Interface;
using Institute_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Institute_WebApi.Repository
{
    public class FacultyRepositiry : IFacultyRepository
    {
        private readonly ApplicationDbContext _context;

        public FacultyRepositiry(ApplicationDbContext context)
        {
            _context = context;
        }
      

        public async Task<Faculty> AddFaculty(Faculty faculty)
        {
           _context.Faculties.Add(faculty);
           await  _context.SaveChangesAsync();
            return faculty;
        }

        public async Task<bool> DeleteFaculty(int facultyId)
        {
            var faculty = await _context.Faculties.FindAsync(facultyId);
            if(faculty == null)
            {
                return false;
            }
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Faculty>> GetAllFacultys()
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task<Faculty> GetFacultyById(int facultyId)
        {
            return await _context.Faculties.Where(x => x.FacultyId == facultyId).FirstOrDefaultAsync();
        }


        public async Task<Faculty> UpdateFaculty(Faculty faculty)
        {
            _context.Entry(faculty).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return faculty;
        }
    }
}
