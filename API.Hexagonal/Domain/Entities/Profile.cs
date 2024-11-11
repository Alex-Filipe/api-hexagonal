using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class Profile : BaseEntity
{
    public Guid ProfileId { get; set; }
    public required string Name { get; set; }
}