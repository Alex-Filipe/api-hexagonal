namespace API.Hexagonal.Domain.Entities;

public abstract class Cooperative
{
    
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required Enterprise Enterprise { get; set; }
}