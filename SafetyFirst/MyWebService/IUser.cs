using MyAPI.Models.DTOs;

namespace MyWebService
{
    public interface IUser
    {
        Task CreateJWT(UserDTO userDTO);
    }
}