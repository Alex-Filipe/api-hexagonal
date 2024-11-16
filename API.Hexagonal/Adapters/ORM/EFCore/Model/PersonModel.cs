namespace API.Hexagonal.Adapters.ORM.EFCore.Model;

public class PersonModel
{
    public int Id { get; set; }
    public required string Name { get; set; }           
    public required string Email { get; set; }          
    public required string PasswordHash { get; set; }   
    public required string Cpf { get; set; }            
    public int Age { get; set; }
    public int ProfileId { get; set; }
    public int RegionId { get; set; }
    public int CityId { get; set; }
    public int SectorId { get; set; }
    public int CooperativeId { get; set; }
    public required ProfileModel Profile { get; set; }
    public required RegionModel Region { get; set; }
    public required CityModel City { get; set; }
    public required SectorModel Sector { get; set; }
    public required CooperativeModel Cooperative { get; set; }
}