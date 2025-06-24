using TechSummary.DTOs.AdminPanel;

namespace TechSummary.Interface
{
    public interface IAdminPanel
    {
        Task<bool> AddCategoryAsync(string name);
        Task<bool> UpdateCategoryAsync(int id, string newName);
        Task<bool> DeleteCategoryAsync(int id);
        Task<List<CategoryDto>> GetAllCategoriesAsync();
    }
}
