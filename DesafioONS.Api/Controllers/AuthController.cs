using DesafioONS.Business.DTOs;
using DesafioONS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioONS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.Authenticate(login.Login, login.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Login or password is incorrect" });
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}
