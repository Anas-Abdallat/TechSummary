using Microsoft.EntityFrameworkCore;
using System;
using TechSummary.DTOs.AuthDTO.ChangePasswordDTO.Request;
using TechSummary.DTOs.AuthDTO.LoginDTO.Request;
using TechSummary.DTOs.AuthDTO.ResetPasswordDTO.Request;
using TechSummary.DTOs.AuthDTO.SignupDTO.Request;
using TechSummary.Helper;
using TechSummary.Interface;
using TechSummary.Models;
using TechSummary.Service;

namespace TechSummary.Service
{

    public class AuthService : IAuthService 
    {
        private readonly TechSummaryContext _context;

        public AuthService(TechSummaryContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterAsync(SignupDTO dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
                return "Email already exists";

            var user = new User
            {
                FullName = dto.Fullname,
                Email = dto.Email,
                PasswordHash = PasswordHasher.Hash(dto.PasswordHash),
                GenderId = dto.GenderId,
                Age = dto.Age
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User registered successfully";
        }

        public async Task<string> LoginAsync(LoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !PasswordHasher.Verify(dto.PasswordHash, user.PasswordHash))
                return "Invalid credentials";

            return "Login successful";
        }

        public async Task<string> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return "User not found";

            user.PasswordHash = PasswordHasher.Hash(dto.NewPassword);
            await _context.SaveChangesAsync();
            return "Password reset successfully";
        }

        public async Task<string> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !PasswordHasher.Verify(dto.CurrentPassword, user.PasswordHash))
                return "Current password is incorrect";

            user.PasswordHash = PasswordHasher.Hash(dto.NewPassword);
            await _context.SaveChangesAsync();
            return "Password changed successfully";
        }
    }
}