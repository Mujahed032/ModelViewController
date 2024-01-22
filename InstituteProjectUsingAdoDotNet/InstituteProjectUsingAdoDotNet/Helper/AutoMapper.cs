using AutoMapper;
using InstituteProjectUsingAdoDotNet.Dto;
using InstituteProjectUsingAdoDotNet.Models;

namespace InstituteProjectUsingAdoDotNet.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
        
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}
