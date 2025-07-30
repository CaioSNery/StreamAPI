using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StreamAPI.Dtos;
using StreamAPI.Interfaces;

namespace StreamAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
        if (loginDto.Username == "admin" && loginDto.Password == "123456")
        {
            var token = _authService.GenerateToken(loginDto.Username, "Admin");
            return Ok(new { token });
        }

        return Unauthorized("Usuário ou senha inválidos");
    }
}

}