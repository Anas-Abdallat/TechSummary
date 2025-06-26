namespace TechSummary.DTOs.AdminPanel
{
    public class UserDto
    {

        public int Id { get; set; }

        public string? FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int? RoleId { get; set; }

        public bool? IsActive { get; set; }
    }
}
