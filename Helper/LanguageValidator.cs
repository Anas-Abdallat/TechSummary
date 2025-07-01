using TechSummary.DTOs.AdminPanel;
using TechSummary.Models;

namespace TechSummary.Helper
{
    public class LanguageValidator
    {
        public static void Validate(string language)
        {
            if (string.IsNullOrWhiteSpace(language))
                throw new ArgumentException("Language cannot be null or empty.", nameof(language));
            if (language.Length > 50)
                throw new ArgumentException("Language name cannot exceed 50 characters.", nameof(language));
            if (language.Any(char.IsDigit))
                throw new ArgumentException("Language name cannot contain digits.", nameof(language));
            if (language.Any(char.IsSymbol))
                throw new ArgumentException("Language name cannot contain symbols.", nameof(language));

        }

        internal static void Validate(LanguageDto language, TechSummaryContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}