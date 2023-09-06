using System.IdentityModel.Tokens.Jwt;
using AuthApi.DTOs;
using AuthApi.Models;
using AuthApi.Services;
using AuthApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service = default!;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            var user = await _service.GetUser(userDto.Email!);

            if(user is not null){
                if(PasswordHasher.VerifyPasswordHash(userDto.Password!,user.PasswordHash,user.PasswordSalt)){
                    return Ok($"Welcome {user.Fullname}!");
                }
                return BadRequest("Invalid password!");
            }
            return NotFound("User not found!");    
        }

        [HttpPost("signup")]
        public IActionResult Signup(UserSignupDto userDto)
        {
            
            PasswordHasher.CreatePasswordHash(userDto.Password!, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Fullname = userDto.Fullname,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _service.AddUser(user);
            return Ok();
        }
    }
}
