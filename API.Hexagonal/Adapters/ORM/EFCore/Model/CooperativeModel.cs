namespace API.Hexagonal.Adapters.ORM.EFCore.Model;

public class CooperativeModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int EnterpriseId { get; set; }
    public required EnterpriseModel Enterprise { get; set; }
}