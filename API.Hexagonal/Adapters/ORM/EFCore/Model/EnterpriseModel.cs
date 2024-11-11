namespace API.Hexagonal.Adapters.ORM.EFCore.Model;

public class EnterpriseModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}