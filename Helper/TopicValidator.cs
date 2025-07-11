using TechSummary.DTOs.AdminPanel;
using TechSummary.Models;

namespace TechSummary.Helper
{
    public class TopicValidator
    {
        public static void Validate(TopicDto input, TechSummaryContext dbContext)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
                throw new ArgumentException("Topic name cannot be empty.");
            
            if (dbContext.Topics.Any(t => t.Name == input.Name && t.Id == input.Id))
                throw new ArgumentException("Topic with the same name already exists in this category.");
        }
    }
}
