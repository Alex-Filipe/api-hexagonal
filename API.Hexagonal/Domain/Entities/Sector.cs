namespace API.Hexagonal.Domain.Entities;

public abstract class Sector
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}