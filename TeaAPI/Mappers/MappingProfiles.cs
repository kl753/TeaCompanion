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

            //Tea Mappings
            CreateMap<Tea, TeaDto>()
                .ReverseMap(); // Allows mapping in both directions
            CreateMap<CreateTeaDto, Tea>();
            CreateMap<UpdateTeaDto, Tea>();

            //User Mappings
            CreateMap<User, UserDto>(); //Don't reverse map, as UserDto doesn't have PasswordHash
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Ignore PasswordHash during creation
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id during creation
                .ForMember(dest =>dest.PasswordHash, opt => opt.Ignore()) // Ignore PasswordHash during creation
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Ignore CreatedAt during creation
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Ignore null values

            //UserTeaStashEntry Mappings
            CreateMap<UserTeaStashEntry, UserTeaStashEntryDto>()
                .ForMember(dest => dest.TeaName, opt => opt.MapFrom(src => src.Tea.Name)); // Map Tea property
            CreateMap<CreateUserTeaStashEntryDto, UserTeaStashEntry>();
            CreateMap<UpdateUserTeaStashEntryDto, UserTeaStashEntry>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Partial update
        }
    }
}
