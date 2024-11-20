using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public class Profile : BaseEntity
{
    public int ProfileId { get; set; }
    public required string Name { get; set; }
}