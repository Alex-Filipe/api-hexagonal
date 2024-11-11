using API.Hexagonal.Adapters.ORM.EFCore.Model;
using API.Hexagonal.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace API.Hexagonal.Adapters.ORM.EFCore.Mappings;

public class EnterpriseProfile : Profile
{
    public EnterpriseProfile()
    {
        // Domain to ORM
        CreateMap<Enterprise, EnterpriseModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnterpriseId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        // ORM to Domain
        CreateMap<EnterpriseModel, Enterprise>()
            .ForMember(dest => dest.EnterpriseId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}