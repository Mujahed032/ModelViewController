using Institute_WebApi.Data;
using Institute_WebApi.Interface;
using Institute_WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Institute_WebApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if(student== null)
            {
                return false;
            }
             _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
           return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
             return await _context.Students.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
