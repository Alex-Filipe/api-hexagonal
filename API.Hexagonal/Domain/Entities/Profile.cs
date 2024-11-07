namespace API.Hexagonal.Domain.Entities;

public abstract class Profile
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}