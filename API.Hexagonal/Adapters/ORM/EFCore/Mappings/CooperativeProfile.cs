using API.Hexagonal.Adapters.ORM.EFCore.Model;
using API.Hexagonal.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace API.Hexagonal.Adapters.ORM.EFCore.Mappings;

public class CooperativeProfile : Profile
{
    public CooperativeProfile()
    {
        // Domain to ORM
        CreateMap<Cooperative, CooperativeModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CooperativeId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Enterprise, opt => opt.MapFrom(src => src.Enterprise));
        
        // ORM to Domain
        CreateMap<CooperativeModel, Cooperative>()
            .ForMember(dest => dest.CooperativeId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Enterprise, opt => opt.MapFrom(src => src.Enterprise));
    }
}