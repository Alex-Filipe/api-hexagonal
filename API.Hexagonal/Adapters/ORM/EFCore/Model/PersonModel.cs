namespace API.Hexagonal.Adapters.ORM.EFCore.Model;

public class PersonModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }           
    public required string Email { get; set; }          
    public required string PasswordHash { get; set; }   
    public required string Cpf { get; set; }            
    public int Age { get; set; }               
    public required ProfileModel Profile { get; set; }
    public required RegionModel Region { get; set; }
    public required CityModel City { get; set; }
    public required SectorModel Sector { get; set; }
    public required CooperativeModel Cooperative { get; set; }
}