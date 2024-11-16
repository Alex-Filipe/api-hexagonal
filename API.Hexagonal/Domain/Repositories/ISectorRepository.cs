using API.Hexagonal.Domain.Entities;

namespace API.Hexagonal.Domain.Repositories;

public interface ISectorRepository
{
    Task<Sector> GetByIdAsync(int id);
}