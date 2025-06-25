namespace TechSummary.DTOs.AuthDTO.SignupDTO.Request
{
    public class SignupDTO
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int GenderId { get; set; }
        public int Age { get; set; }
    }
}
