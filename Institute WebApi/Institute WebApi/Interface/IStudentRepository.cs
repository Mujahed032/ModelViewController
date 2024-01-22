using Institute_WebApi.Models;

namespace Institute_WebApi.Interface
{
  
        public interface IStudentRepository
        {
            Task<Student> GetStudentById(int studentId);
            Task<IEnumerable<Student>> GetAllStudents();
            Task<Student> AddStudent(Student student);
            Task<Student> UpdateStudent(Student student);
            Task<bool> DeleteStudent(int studentId);
        }

    
}
