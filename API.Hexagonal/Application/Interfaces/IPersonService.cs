using API.Hexagonal.Domain.Entities;
using API.Hexagonal.Port.DTOs;

namespace API.Hexagonal.Application.Interfaces;

public interface IPersonService
{
    Task<Person> GetByIdAsync(int personId);
    Task<IEnumerable<Person>> GetAllAsync();
    Task CreateAsync(PersonCreateOrUpdateDto dto);
    Task UpdateAsync(PersonCreateOrUpdateDto dto);
    Task DeleteAsync(int personId);
}