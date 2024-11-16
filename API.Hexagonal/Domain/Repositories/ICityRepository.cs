using API.Hexagonal.Domain.Entities;

namespace API.Hexagonal.Domain.Repositories;

public interface ICityRepository
{
    Task<City> GetByIdAsync(int id);
}

