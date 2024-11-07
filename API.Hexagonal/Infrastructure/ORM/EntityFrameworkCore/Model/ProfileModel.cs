namespace API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Model;

public abstract class ProfileModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}