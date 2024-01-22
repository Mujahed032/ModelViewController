using InstituteProjectUsingAdoDotNet.Models;

namespace InstituteProjectUsingAdoDotNet.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudent();

        Task<Student> InsertStudent(Student student);
    }
}
