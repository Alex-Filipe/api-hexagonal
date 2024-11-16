using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class Profile : BaseEntity
{
    public int ProfileId { get; set; }
    public required string Name { get; set; }
}