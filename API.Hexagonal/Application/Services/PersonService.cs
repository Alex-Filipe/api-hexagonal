using API.Hexagonal.Application.Interfaces;
using API.Hexagonal.Domain.Entities;
using API.Hexagonal.Domain.Repositories;
using API.Hexagonal.Domain.Services;
using API.Hexagonal.Port.DTOs;
using AutoMapper;

namespace API.Hexagonal.Application.Services
{
    public class PersonService(IPersonRepository personRepository, IMapper mapper, IPasswordHasher passwordHasher) : IPersonService
    {
        public async Task<Person> GetByIdAsync(int personId)
        {
            var personModel = await personRepository.GetByIdAsync(personId);
            
            return personModel;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var personModels = await personRepository.GetAllAsync();
            
            return mapper.Map<IEnumerable<Person>>(personModels);
        }

        public async Task CreateAsync(PersonCreateOrUpdateDto dto)
        {
            var person = mapper.Map<Person>(dto);
            // var sector = await entityRepository.GetRequiredEntityAsync(sectorRepository.GetByIdAsync, dto.Setor_id, "Setor");
            
            person.SetPassword(dto.Password, dto.Confirm_password, passwordHasher);
            
            await personRepository.CreateAsync(person);
        }


        public async Task UpdateAsync(PersonCreateOrUpdateDto dto)
        {
            var person = mapper.Map<Person>(dto);
            
            await personRepository.UpdateAsync(person);
        }

        public async Task DeleteAsync(int personId)
        {
            await personRepository.DeleteAsync(personId);
        }
    }
}