using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public class Sector : BaseEntity
{
    public int SectorId { get; set; }
    public required string Name { get; set; }
}