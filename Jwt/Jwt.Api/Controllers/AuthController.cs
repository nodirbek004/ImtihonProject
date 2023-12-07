using Jwt.Api.Models;
using Jwt.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

    public class AuthController : ControllerBase
    {
        private readonly TokenGeneratorService _tokenGenerator;

        public AuthController(TokenGeneratorService tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginDTO login)
        {
            var token = _tokenGenerator.GenerateToken(login);
            return Ok(token);
        }
    }

