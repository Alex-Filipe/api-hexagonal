namespace API.Hexagonal.Adapters.ORM.EFCore.Model;

public class SectorModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}