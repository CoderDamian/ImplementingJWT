using MyAPI.Models;
using MyAPI.Models.DTOs;

namespace MyAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<UserDTO> _users;

        public UserRepository()
        {
            _users.Add(new UserDTO
            {
                UserName = "joydipkanjilal",
                Password = "joydip123",
                Role = "manager"
            });
            _users.Add(new UserDTO
            {
                UserName = "michaelsanders",
                Password = "michael321",
                Role = "developer"
            });
            _users.Add(new UserDTO
            {
                UserName = "stephensmith",
                Password = "stephen123",
                Role = "tester"
            });
            _users.Add(new UserDTO
            {
                UserName = "rodpaddock",
                Password = "rod123",
                Role = "admin"
            });
            _users.Add(new UserDTO
            {
                UserName = "rexwills",
                Password = "rex321",
                Role = "admin"
            });
        }

        public UserDTO? GetUser(User user)
        {
            return _users.Where(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password)).FirstOrDefault();
        }
    }
}
