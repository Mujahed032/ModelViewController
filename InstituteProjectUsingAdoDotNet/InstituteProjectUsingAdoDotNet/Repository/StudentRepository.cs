using InstituteProjectUsingAdoDotNet.Interface;
using InstituteProjectUsingAdoDotNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace InstituteProjectUsingAdoDotNet.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SP_GetStudentAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var students = new List<Student>();
                        while (await reader.ReadAsync())
                        {
                            var student = new Student
                            {
                                StudentId = reader.GetInt32(reader.GetOrdinal("StudentId")),
                                StudentCode = reader.GetString(reader.GetOrdinal("StudentCode")),
                                StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                                Gender = Convert.ToChar(reader.GetString(reader.GetOrdinal("Gender"))),
                                MobileNumber = reader.GetString(reader.GetOrdinal("MobileNumber")),
                                EmailId = reader.GetString(reader.GetOrdinal("EmailId")),
                                JoinDate = reader.GetDateTime(reader.GetOrdinal("JoinDate")).ToString(),
                            };
                            students.Add(student);
                        }
                        return students;
                    }
                }
            }
        }

        public async Task<Student> InsertStudent(Student student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SP_InsertStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentCode", student.StudentCode);
                    command.Parameters.AddWithValue("@StudentName", student.StudentName);
                    command.Parameters.AddWithValue("@Gender", student.Gender.ToString());
                    command.Parameters.AddWithValue("@MobileNumber", student.MobileNumber);
                    command.Parameters.AddWithValue("@EmailId", student.EmailId);
                    command.Parameters.AddWithValue("@JoinDate", student.JoinDate).ToString();
                    await command.ExecuteNonQueryAsync();
                }
            }
            return student;
        }
    }
    
}
