using Institute_WebApi.Models;

namespace Institute_WebApi.Interface
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseById(int CourseId);
        Task<IEnumerable<Course>> GetAllCourse();
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<bool> DeleteCourse(int courseId);
    }
}
