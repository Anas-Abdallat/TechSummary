using TechSummary.DTOs.AuthDTO.ChangePasswordDTO.Request;
using TechSummary.DTOs.AuthDTO.LoginDTO.Request;
using TechSummary.DTOs.AuthDTO.ResetPasswordDTO.Request;
using TechSummary.DTOs.AuthDTO.SignupDTO.Request;

namespace TechSummary.Interface
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(SignupDTO dto);
        Task<string> LoginAsync(LoginDTO dto);
        Task<string> ResetPasswordAsync(ResetPasswordDto dto);
        Task<string> ChangePasswordAsync(ChangePasswordDto dto);
    }
}

