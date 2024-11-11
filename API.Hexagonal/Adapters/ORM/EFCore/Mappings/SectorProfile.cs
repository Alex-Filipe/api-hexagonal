using API.Hexagonal.Adapters.ORM.EFCore.Model;
using API.Hexagonal.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace API.Hexagonal.Adapters.ORM.EFCore.Mappings;

public class SectorProfile : Profile
{
    public SectorProfile()
    {
        // Domain to ORM
        CreateMap<Sector, SectorModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SectorId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        // ORM to Domain
        CreateMap<SectorModel, Sector>()
            .ForMember(dest => dest.SectorId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}