using MyAPI.Models;
using MyAPI.Models.DTOs;

namespace MyAPI.Data.Repositories
{
    public interface IUserRepository
    {
        UserDTO? GetUser(User user);
    }
}
