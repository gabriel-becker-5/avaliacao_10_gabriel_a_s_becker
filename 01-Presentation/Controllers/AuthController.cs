using _02_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _01_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenservice;

        public AuthController(ITokenService tokenservice)
        {
            _tokenservice = tokenservice;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Logar(string usuario, string senha)
        {
            if (usuario == "admin" && senha == "123456")
            {
                var token = _tokenservice.GerarToken(usuario);
                return Ok(new { token });
            }

            return BadRequest();
        }
    }
}