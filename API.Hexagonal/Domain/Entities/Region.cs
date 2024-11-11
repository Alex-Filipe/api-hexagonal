using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class Region : BaseEntity
{
    public Guid RegionId { get; set; }
    public required string Name { get; set; }
}