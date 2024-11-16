using API.Hexagonal.Domain.Entities;

namespace API.Hexagonal.Domain.Repositories;

public interface IRegionRepository
{
    Task<Region> GetByIdAsync(int id);
}