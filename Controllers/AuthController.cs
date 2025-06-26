using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSummary.DTOs.AuthDTO.ChangePasswordDTO.Request;
using TechSummary.DTOs.AuthDTO.LoginDTO.Request;
using TechSummary.DTOs.AuthDTO.ResetPasswordDTO.Request;
using TechSummary.DTOs.AuthDTO.SignupDTO.Request;
using TechSummary.Interface;

namespace TechSummary.Controllers
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
        public async Task<IActionResult> Register(SignupDTO dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            var result = await _authService.ResetPasswordAsync(dto);
            return Ok(result);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword( ChangePasswordDto dto)
        {
            var result = await _authService.ChangePasswordAsync(dto);
            return Ok(result);
        }

        //[HttpPost("logout")]
        //public IActionResult Logout()
        //{
        //    // stateless APIs do not store sessions — logout handled client-side
        //    return Ok("Logout successful");
        //}
    }

}
