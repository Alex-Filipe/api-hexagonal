namespace API.Hexagonal.Domain.Entities;

public abstract class City
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}