using AutoMapper;
using University_Management_System.Model.Domain;
using University_Management_System.Model.DTO;

namespace University_Management_System.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Student,
                StudentDto>().ReverseMap();
            CreateMap<StudentResponseDto, StudentDto>().ReverseMap();
            CreateMap<Student,StudentResponseDto>().ReverseMap();
            CreateMap<int, RollNoDto>()
           .ForMember(dest => dest.RollNo, opt => opt.MapFrom(src => src));

        }
    }
}
