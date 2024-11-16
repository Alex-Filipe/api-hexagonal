using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class Region : BaseEntity
{
    public int RegionId { get; set; }
    public required string Name { get; set; }
}