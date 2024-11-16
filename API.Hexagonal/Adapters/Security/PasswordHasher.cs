using API.Hexagonal.Domain.Services;

namespace API.Hexagonal.Adapters.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}