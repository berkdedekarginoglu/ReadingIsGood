using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Entities.DTOs;
using System.Threading.Tasks;

namespace ReadingIsGood.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]

        public IActionResult RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            var registerResult =  _authService.Register(userForRegisterDto);

            if (!registerResult.Success)
                return BadRequest(registerResult);

            var result = _authService.CreateAccessToken(registerResult.Data);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);

            
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin =  _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
                return BadRequest(userToLogin);

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
            
        }
    }
}
