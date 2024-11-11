namespace API.Hexagonal.Adapters.ORM.EFCore.Model;

public class CooperativeModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required EnterpriseModel Enterprise { get; set; }
}