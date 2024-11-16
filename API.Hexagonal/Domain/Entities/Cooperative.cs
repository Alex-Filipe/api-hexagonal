using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class Cooperative : BaseEntity
{
    
    public int CooperativeId { get; set; }
    public required string Name { get; set; }
    public int EnterpriseId { get; set; }
    public required Enterprise Enterprise { get; set; }
}