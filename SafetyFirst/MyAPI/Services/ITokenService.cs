using MyAPI.Models.DTOs;

namespace MyAPI.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string key, string issuer, string audience, string token);
    }
}
