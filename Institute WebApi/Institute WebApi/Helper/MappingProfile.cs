using AutoMapper;
using Institute_WebApi.Dto;
using Institute_WebApi.Models;

namespace Institute_WebApi.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<FacultyDto , Faculty>();
            CreateMap<Faculty, FacultyDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>();
        }
    }
}
