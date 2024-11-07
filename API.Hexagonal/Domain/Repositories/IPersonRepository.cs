using API.Hexagonal.Domain.Entities;

namespace API.Hexagonal.Domain.Repositories;

public interface IPersonRepository
{
    Task<Person> CreateAsync(Person pessoa);
    Task<Person> GetPorIdAsync(Guid id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task UpdateAsync(Person pessoa);
    Task DeleteAsync(Guid id);
}