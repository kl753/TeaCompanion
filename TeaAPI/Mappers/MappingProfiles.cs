using AutoMapper;
using TeaAPI.Infrastructure;
using TeaAPI.Models;

namespace TeaAPI.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Create mappings between DTOs and Models
            //Source -> Destination
            CreateMap<Tea, TeaDTO>().ReverseMap(); // For TeaDTO <-> Tea
            CreateMap<CreateTeaDTO, Tea>(); // For CreateTeaDTO -> Tea
            CreateMap<UpdateTeaDTO, Tea>(); // For UpdateTeaDTO -> Tea
        }
    }
}
