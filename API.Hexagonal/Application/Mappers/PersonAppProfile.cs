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
            .ForMember(dest => dest.PersonId, opt => opt.Ignore()) 
            .ForMember(dest => dest.ProfileId, opt => opt.MapFrom(src => src.Perfil_id))
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.Regiao_id))
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Cidade_id))
            .ForMember(dest => dest.SectorId, opt => opt.MapFrom(src => src.Setor_id))
            .ForMember(dest => dest.CooperativeId, opt => opt.MapFrom(src => src.Cooperativa_id));
    }
}