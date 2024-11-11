using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class City : BaseEntity
{
    public Guid CityId { get; set; }
    public required string Name { get; set; }
}