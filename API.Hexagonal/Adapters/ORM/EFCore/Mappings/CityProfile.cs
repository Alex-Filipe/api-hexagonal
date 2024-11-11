using API.Hexagonal.Adapters.ORM.EFCore.Model;
using API.Hexagonal.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace API.Hexagonal.Adapters.ORM.EFCore.Mappings;

public class CityProfile : Profile
{
    public CityProfile()
    {
        // Domain to ORM
        CreateMap<City, CityModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CityId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        // ORM to Domain
        CreateMap<CityModel, City>()
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
