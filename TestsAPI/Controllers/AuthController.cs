using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Models.Auth;
using TestsAPI.DTO;
using TestsAPI.Repository;
using TestsAPI.Services;

namespace TestsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITestsRepository _testRepository;
        private readonly JwtService _jwtService;

        public AuthController(ITestsRepository testRepository, JwtService jwtService)
        {
            _testRepository = testRepository;
            _jwtService = jwtService;
        }

        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_testRepository.GetAllUsers());
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            return Created("Success", _testRepository.Register(user));
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string email)
        {
            if (email == null) return BadRequest("Email is null");
            var res = _testRepository.DeleteUser(email);
            if (res == false) return BadRequest("TestRepository.DeleteUser(string email) return false. Its mean that there is some problems");
            return Ok($"User with email {email} has been deleted successful");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _testRepository.GetUserByEmail(dto.Email);
            if (user == null) return BadRequest("Invalid email or password");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.HashedPassword))
            {
                return BadRequest("Invalid email or password");
            }

            var jwt = _jwtService.Generate(user.Id);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok($"You successfully logined as {dto.Email}");
        }

        [HttpGet("get-logined-user")]
        public IActionResult GetUserByJwt()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _testRepository.GetUserById(userId);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
        [HttpPost("logout")]
        public IActionResult logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok("You successfully logout");
        }
    }
}
