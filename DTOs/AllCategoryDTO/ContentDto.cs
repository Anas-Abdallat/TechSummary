namespace TechSummary.DTOs.AllCategoryDTO
{
    public class ContentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; } // Video / PDF / External
        public string Url { get; set; }
        public int TopicId { get; set; }
    }
}
