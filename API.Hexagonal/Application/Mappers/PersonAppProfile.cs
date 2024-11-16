using API.Hexagonal.Domain.Entities;
using API.Hexagonal.Port.DTOs;
using Profile = AutoMapper.Profile;

namespace API.Hexagonal.Application.Mappers;

public class PersonAppProfile : Profile
{
    public PersonAppProfile()
    {
        CreateMap<PersonCreateOrUpdateDto, Person>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.Confirm_password))
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Idade))
            // Propriedades que serão atribuídas manualmente
            .ForMember(dest => dest.PersonId, opt => opt.Ignore()) 
            .ForMember(dest => dest.Profile, opt => opt.Ignore()) 
            .ForMember(dest => dest.Region, opt => opt.Ignore()) 
            .ForMember(dest => dest.City, opt => opt.Ignore())
            .ForMember(dest => dest.Sector, opt => opt.Ignore())
            .ForMember(dest => dest.Cooperative, opt => opt.Ignore());
    }
}