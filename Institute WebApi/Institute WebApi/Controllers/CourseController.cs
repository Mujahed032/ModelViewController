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
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = _mapper.Map<List<CourseDto>>(await _courseRepository.GetAllCourse());
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            var addCourse = await _courseRepository.AddCourse(course);
            var newCourse = _mapper.Map<CourseDto>(addCourse);
            return CreatedAtAction(nameof(GetCourseById), new { id = newCourse.CourseId }, newCourse);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCourseById(int Id)
        {
            var course = _mapper.Map<CourseDto>(await _courseRepository.GetCourseById(Id));
            return Ok(course);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCourse(int Id, CourseDto courseDto)
        {
            if (Id != courseDto.CourseId)
            {
                return BadRequest();
            }
            var course = _mapper.Map<Course>(courseDto);
            var updatedCourse = await _courseRepository.UpdateCourse(course);
            var newCourse = _mapper.Map<CourseDto>(updatedCourse);
            return Ok(newCourse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCourse(int Id)
        {
            var result = await _courseRepository.DeleteCourse(Id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Successfully Deleted");
        }

    }
}
