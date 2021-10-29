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
    }
}
