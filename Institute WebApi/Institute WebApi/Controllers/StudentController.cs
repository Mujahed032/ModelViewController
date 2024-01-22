using AutoMapper;
using Institute_WebApi.Dto;
using Institute_WebApi.Interface;
using Institute_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Institute_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = _mapper.Map<List<StudentDto>>(await _studentRepository.GetAllStudents());
           
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var newStudent = await _studentRepository.AddStudent(student);
            var newStudentDto = _mapper.Map<StudentDto>(newStudent);
            return CreatedAtAction(nameof(GetAllStudents), new { id = newStudentDto.StudentId }, newStudentDto);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var student =_mapper.Map<StudentDto>(await _studentRepository.GetStudentById(Id));
            if (student == null)
            {
                return NotFound();
            }
           
            return Ok(student);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudent(int Id, StudentDto studentDto)
        {
            if (Id != studentDto.StudentId)
            {
                return BadRequest();
            }
            var student = _mapper.Map<Student>(studentDto);
            var addstudent = await _studentRepository.UpdateStudent(student);
            var studentdto = _mapper.Map<StudentDto>(addstudent);
            return Ok(studentdto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentRepository.DeleteStudent(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Successfully Deleted");
        }
    }
}
