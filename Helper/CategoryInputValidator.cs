using TechSummary.DTOs.AdminPanel;
using TechSummary.Models;
using System;
using System.Linq;

namespace TechSummary.Validators
{
    public static class CategoryInputValidator
    {
        public static void Validate(CategoryInpu input, TechSummaryContext DB)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");

            if (string.IsNullOrWhiteSpace(input.Name))
                throw new ArgumentException("Category name cannot be null or empty.", nameof(input.Name));

            if (input.Name.Length > 100)
                throw new ArgumentException("Category name cannot exceed 100 characters.", nameof(input.Name));

            if (input.Name.Any(char.IsDigit))
                throw new ArgumentException("Category name cannot contain digits.", nameof(input.Name));

            if (input.Name.Any(char.IsSymbol))
                throw new ArgumentException("Category name cannot contain symbols.", nameof(input.Name));


            if (DB.Categories.Any(c => c.Name == input.Name))
                input.Name = null;
        }     
    }
}
