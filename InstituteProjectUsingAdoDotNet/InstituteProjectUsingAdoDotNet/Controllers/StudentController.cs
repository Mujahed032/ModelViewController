using AutoMapper;
using InstituteProjectUsingAdoDotNet.Dto;
using InstituteProjectUsingAdoDotNet.Interface;
using InstituteProjectUsingAdoDotNet.Models;
using InstituteProjectUsingAdoDotNet.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstituteProjectUsingAdoDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository, IMapper mapper)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            
                var students = await _studentRepository.GetAllStudent();
                var studentDTOs = _mapper.Map<IEnumerable<StudentDto>>(students);
                return Ok(studentDTOs);
           
        }

        [HttpPost]
        public async Task<IActionResult> InsertStudent(StudentDto studentDTO)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDTO);
                await _studentRepository.InsertStudent(student);
                var insertedStudentDTO = _mapper.Map<StudentDto>(student);
                return Ok(insertedStudentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting a new student.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
