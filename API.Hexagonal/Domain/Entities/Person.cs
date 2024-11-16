using API.Hexagonal.Domain.Services;
using API.Hexagonal.Shared;

namespace API.Hexagonal.Domain.Entities;

public class Person : BaseEntity
{
    public int PersonId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
    public required string Cpf { get; set; }
    public required int Age { get; set; }
    public int ProfileId { get; set; }
    public int RegionId { get; set; }
    public int CityId { get; set; }
    public int SectorId { get; set; }
    public int CooperativeId { get; set; }
    public required Profile Profile { get; set; }
    public required Region Region { get; set; }
    public required City City{ get; set; }
    public required Sector Sector { get; set; }
    public required Cooperative Cooperative { get; set; }
    
    public void SetPassword(string password, string confirmPassword, IPasswordHasher passwordHasher)
    {
        if (password != confirmPassword)
        {
            throw new ArgumentException("As senhas não correspondem.");
        }

        Password = passwordHasher.Hash(password);
    }
}