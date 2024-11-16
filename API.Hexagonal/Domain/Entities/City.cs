using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class City : BaseEntity
{
    public int CityId { get; set; }
    public required string Name { get; set; }
}