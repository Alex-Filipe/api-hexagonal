using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public class City : BaseEntity
{
    public int CityId { get; set; }
    public required string Name { get; set; }
}