namespace TechSummary.DTOs.AllCategoryDTO
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ResourceType { get; set; } // Video, PDF, External
        public string Url { get; set; }
    }
}
