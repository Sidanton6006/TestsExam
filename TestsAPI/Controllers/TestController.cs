using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsAPI.Repository;

namespace TestsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestsRepository _testsRepository;

        public TestController(ITestsRepository testsRepository)
        {
            _testsRepository = testsRepository;
        }

        [HttpGet("get-all-tests")]
        public IActionResult GetAllTests()
        {
            return Ok(_testsRepository.GetAllTests());
        }
        [HttpPost("create")]
        public IActionResult CreateTest()
        {
            return Ok();
        }
    }
}
