using AutoMapper;
using WebApplication11.Data.Identity;

namespace WebApplication11.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            this.CreateMap<Student, StudentModel>()
                .ForMember(dst => dst.BirthDate, 
                opt => opt.MapFrom(src => src.BirthDate.Date));

            this.CreateMap<StudentModel, Student>();
        }
    }
}

//.ForMember(dst => dst.FullName, 
//opt => opt.MapFrom(src => src.Name + " " + src.Id))
