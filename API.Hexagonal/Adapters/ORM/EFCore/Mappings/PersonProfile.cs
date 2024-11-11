using API.Hexagonal.Adapters.ORM.EFCore.Model;
using API.Hexagonal.Domain.Entities;
using Profile = AutoMapper.Profile;


namespace API.Hexagonal.Adapters.ORM.EFCore.Mappings;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        // Domain to ORM
        CreateMap<Person, PersonModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
            .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Sector))
            .ForMember(dest => dest.Cooperative, opt => opt.MapFrom(src => src.Cooperative))
            .ForSourceMember(src => src.ConfirmPassword, opt => opt.DoNotValidate());

        // ORM to Domain
        CreateMap<PersonModel, Person>()
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
            .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
            .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Sector))
            .ForMember(dest => dest.Cooperative, opt => opt.MapFrom(src => src.Cooperative));
    }
}