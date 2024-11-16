using API.Hexagonal.Adapters.ORM.EFCore.Context;
using AutoMapper;
using API.Hexagonal.Domain.Entities;
using API.Hexagonal.Adapters.ORM.EFCore.Model;
using API.Hexagonal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Hexagonal.Adapters.ORM.EFCore.Repositories
{
    public class PersonRepository(EFContext context, IMapper mapper) : IPersonRepository
    {
        public async Task<Person> CreateAsync(Person person)
        {
            var personModel = mapper.Map<PersonModel>(person);
            context.Persons.Add(personModel);
            await context.SaveChangesAsync();

            // Atualiza o ID da entidade de domínio com o ID gerado pelo banco
            person.PersonId = personModel.Id;
            return person;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            var personModel = await context.Persons
                .Include(p => p.Profile)
                .Include(p => p.Region)
                .Include(p => p.City)
                .Include(p => p.Sector)
                .Include(p => p.Cooperative)
                .FirstOrDefaultAsync(p => p.Id == id);

            return mapper.Map<Person>(personModel);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var personModels = await context.Persons
                .Include(p => p.Profile)
                .Include(p => p.Region)
                .Include(p => p.City)
                .Include(p => p.Sector)
                .Include(p => p.Cooperative)
                .ToListAsync();

            return mapper.Map<IEnumerable<Person>>(personModels);
        }

        public async Task UpdateAsync(Person person)
        {
            var personModel = mapper.Map<PersonModel>(person);
            context.Persons.Update(personModel);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var personModel = await context.Persons.FindAsync(id);
            if (personModel != null)
            {
                context.Persons.Remove(personModel);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Person not found.");
            }
        }
    }
}
