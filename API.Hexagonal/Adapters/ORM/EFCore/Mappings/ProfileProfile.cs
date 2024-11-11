using API.Hexagonal.Adapters.ORM.EFCore.Model;
using AutoMapper;

namespace API.Hexagonal.Adapters.ORM.EFCore.Mappings;

public class ProfileProfile : Profile
{
    public ProfileProfile()
    {
        // Domain to ORM
        CreateMap<Domain.Entities.Profile, ProfileModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProfileId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        // ORM to Domain
        CreateMap<ProfileModel, Domain.Entities.Profile>()
            .ForMember(dest => dest.ProfileId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}