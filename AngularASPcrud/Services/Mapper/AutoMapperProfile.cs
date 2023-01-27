
using AngularASPcrud.Domain.Models;
using AutoMapper;

namespace AngularASPcrud.Services.Mapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }


    }
}
