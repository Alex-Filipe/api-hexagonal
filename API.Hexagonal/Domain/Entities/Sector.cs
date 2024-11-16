using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class Sector : BaseEntity
{
    public int SectorId { get; set; }
    public required string Name { get; set; }
}