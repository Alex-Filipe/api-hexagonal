namespace API.Hexagonal.Infrastructure.ORM.EFCore.Model;

public class CooperativeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EnterpriseModel Enterprise { get; set; }
}