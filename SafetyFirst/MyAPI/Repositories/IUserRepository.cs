using MyAPI.DTOs;
using MyAPI.Models;

namespace MyAPI.Repositories
{
    public interface IUserRepository
    {
        UserDTO? GetUser(User user);
    }
}
