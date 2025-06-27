namespace TechSummary.DTOs.ContentFilterDto.Request
{
    public class ContentFilterDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int Views { get; set; }
        public DateTime CreationDate { get; set; }
        public double AverageRating { get; set; }
    }
}
