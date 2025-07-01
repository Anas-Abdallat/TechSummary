namespace TechSummary.DTOs.AdminPanel
{
    public class LanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
