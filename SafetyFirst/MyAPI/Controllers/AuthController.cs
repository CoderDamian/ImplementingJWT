using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Models;
using MyAPI.Models.DTOs;
using MyAPI.Services;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext myDb;
        private readonly ITokenService tokenService;

        public AuthController(MyDbContext myDb, ITokenService tokenService)
        {
            this.myDb = myDb;
            this.tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest("Invalid client request");

            User? user = await this.myDb.Users.Where(u => u.UserName.Equals(userDTO.UserName) && u.Password.Equals(userDTO.Password)).FirstOrDefaultAsync();

            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var token = this.tokenService.BuildToken("superSecretKey@345", "https://localhost:5001", userDTO);

                return Ok(new AuthenticatedResponse() { Token = token });
            }
        }
    }
}
