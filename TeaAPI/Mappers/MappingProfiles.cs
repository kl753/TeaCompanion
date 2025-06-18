/*AutoMapper helps map properties between objects,
 * such as between DTOs and entity models.
 */
using AutoMapper;
using TeaAPI.DTOs; // Assuming DTOs are in the DTOs namespace
using TeaAPI.Models; // Assuming the Tea model is in the Models namespace

namespace TeaAPI.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Create mappings between DTOs and entity models
            //Source -> Destination
            CreateMap<Tea, TeaDto>()
                .ReverseMap(); // Allows mapping in both directions
            CreateMap<CreateTeaDto, Tea>();
            CreateMap<UpdateTeaDto, Tea>();
        }
    }
}
