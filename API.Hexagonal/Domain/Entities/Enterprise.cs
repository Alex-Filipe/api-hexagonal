using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class Enterprise : BaseEntity
{
    public int EnterpriseId { get; set; }
    public required string Name { get; set; }
}