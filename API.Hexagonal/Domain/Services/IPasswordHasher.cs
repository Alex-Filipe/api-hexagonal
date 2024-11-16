namespace API.Hexagonal.Domain.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password);
    }
}