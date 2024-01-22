using AutoMapper;
using InstituteProjectUsingAdoDotNet.Dto;
using InstituteProjectUsingAdoDotNet.Interface;
using InstituteProjectUsingAdoDotNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstituteProjectUsingAdoDotNet.Controllers
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
            var courses = await _courseRepository.GetAllCourses();
            var courseDTOs = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(courseDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCourse(CourseDto courseDTO)
        {
            var course = _mapper.Map<Course>(courseDTO);
            await _courseRepository.InsertCourse(course);
            var insertedCourseDTO = _mapper.Map<CourseDto>(course);
            return Ok(insertedCourseDTO);
        }
    }
}
