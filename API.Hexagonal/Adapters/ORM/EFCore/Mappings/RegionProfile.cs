using API.Hexagonal.Adapters.ORM.EFCore.Model;
using API.Hexagonal.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace API.Hexagonal.Adapters.ORM.EFCore.Mappings;

public class RegionProfile : Profile
{
    public RegionProfile()
    {
        // Domain to ORM
        CreateMap<Region, RegionModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RegionId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        // ORM to Domain
        CreateMap<RegionModel, Region>()
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}