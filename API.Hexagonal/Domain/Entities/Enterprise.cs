using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public abstract class Enterprise : BaseEntity
{
    public Guid EnterpriseId { get; set; }
    public required string Name { get; set; }
}