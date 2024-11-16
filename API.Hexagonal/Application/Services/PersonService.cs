using API.Hexagonal.Application.Interfaces;
using API.Hexagonal.Domain.Entities;
using API.Hexagonal.Domain.Repositories;
using API.Hexagonal.Domain.Services;
using API.Hexagonal.Port.DTOs;
using AutoMapper;

namespace API.Hexagonal.Application.Services
{
    public class PersonService(IPersonRepository personRepository, ICityRepository cityRepository, IMapper mapper, IPasswordHasher passwordHasher) : IPersonService
    {
        public async Task<Person> GetByIdAsync(Guid personId)
        {
            var personModel = await personRepository.GetByIdAsync(personId);
            
            return mapper.Map<Person>(personModel);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var personModels = await personRepository.GetAllAsync();
            
            return mapper.Map<IEnumerable<Person>>(personModels);
        }

        public async Task CreateAsync(PersonCreateOrUpdateDto dto)
        {
            var person = mapper.Map<Person>(dto);

            var city = await GetRequiredEntityAsync(cityRepository.GetByIdAsync, dto.Cidade_id, "Cidade");
            
            person.City = city;
            // person.Profile = profile;
            // person.Region = region;
            // person.Sector = sector;
            // person.Cooperative = cooperative;
            person.SetPassword(dto.Password, dto.Confirm_password, passwordHasher);
            
            await personRepository.CreateAsync(person);
        }


        public async Task UpdateAsync(PersonCreateOrUpdateDto dto)
        {
            var person = mapper.Map<Person>(dto);
            
            await personRepository.UpdateAsync(person);
        }

        public async Task DeleteAsync(Guid personId)
        {
            await personRepository.DeleteAsync(personId);
        }
        
        private static async Task<T> GetRequiredEntityAsync<T, TKey>(
            Func<TKey, Task<T>> getByIdFunc, TKey id, string entityName)
            where T : class
        {
            var entity = await getByIdFunc(id);
            if (entity == null)
            {
                throw new Exception($"{entityName} com ID '{id}' não foi encontrada.");
            }
            return entity;
        }


    }
}