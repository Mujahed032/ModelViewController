using InstituteProjectUsingAdoDotNet.Dto;
using InstituteProjectUsingAdoDotNet.Models;

namespace InstituteProjectUsingAdoDotNet.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> InsertCourse(Course course);
    }
}
