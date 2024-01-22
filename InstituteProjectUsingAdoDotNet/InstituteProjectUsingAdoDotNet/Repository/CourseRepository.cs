using InstituteProjectUsingAdoDotNet.Interface;
using InstituteProjectUsingAdoDotNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace InstituteProjectUsingAdoDotNet.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string _connectionString;

        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SP_GetCourses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var courses = new List<Course>();
                        while (await reader.ReadAsync())
                        {
                            var course = new Course
                            {
                                CourseId = reader.GetInt32(reader.GetOrdinal("CourseId")),
                                CourseCode = reader.GetString(reader.GetOrdinal("CourseCode")),
                                CourseName = reader.GetString(reader.GetOrdinal("CourseName")),
                                CourseDuration = reader.GetInt32(reader.GetOrdinal("CourseDuration")),
                                Prerequisite = reader.GetString(reader.GetOrdinal("Prerequisite"))
                            };
                            courses.Add(course);
                        }
                        return courses;
                    }
                }
            }
        }

        public async Task<Course> InsertCourse(Course course)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SP_InsertCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@CourseCode", course.CourseCode);
                    command.Parameters.AddWithValue("@CourseName", course.CourseName);
                    command.Parameters.AddWithValue("@CourseDuration", course.CourseDuration);
                    command.Parameters.AddWithValue("@CourseFee", course.CourseFee);
                    command.Parameters.AddWithValue("@Prerequisite", course.Prerequisite);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return course;
        }
    }
}
