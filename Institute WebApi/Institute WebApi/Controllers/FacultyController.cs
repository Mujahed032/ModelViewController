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
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public FacultyController(IFacultyRepository facultyRepository, IMapper mapper)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFaculties()
        {
            var facult =_mapper.Map<List<FacultyDto>>(await _facultyRepository.GetAllFacultys());
            return Ok(facult);

        }

        [HttpPost]
        public async Task<IActionResult> AddFaculty(FacultyDto facultydto)
        {
            var faculty = _mapper.Map<Faculty>(facultydto);
            var addfaculty = await _facultyRepository.AddFaculty(faculty);
            var newfaculty = _mapper.Map<FacultyDto>(addfaculty);
            return CreatedAtAction(nameof(GetFacultyById), new {id = newfaculty.FacultyId}, newfaculty);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetFacultyById(int Id)
        {
            var faculty =_mapper.Map<FacultyDto>(await _facultyRepository.GetFacultyById(Id));
            return Ok(faculty);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpadteFaculty(int Id, FacultyDto facultyDto)
        {
            if(Id != facultyDto.FacultyId)
            {
                return BadRequest();
            }
            var faculty = _mapper.Map<Faculty>(facultyDto);
            var addfaculty = await _facultyRepository.UpdateFaculty(faculty);
            var newfaculty = _mapper.Map<FacultyDto>(addfaculty);
            return Ok(newfaculty);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFaculty(int Id)
        {
            var result = await _facultyRepository.DeleteFaculty(Id);
            if (!result)
            {
               return NotFound();
            }
            return Ok("Successfully Deleted");
        }
        
    }
}
