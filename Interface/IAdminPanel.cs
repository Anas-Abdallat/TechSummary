using TechSummary.DTOs.AdminPanel;

namespace TechSummary.Interface
{
    public interface IAdminPanel
    {
        Task<string> AddCategoryAsync(CategoryInpu input);
        Task<bool> UpdateCategoryAsync(UpdateCategoryInput input);
        Task<bool> DeleteCategoryAsync(int id);
        Task<List<CategoryDto>> GetAllCategoriesAsync();




        //Task<bool> AddLanguageAsync(LanguageDto language);
        //Task<bool> UpdateLanguageAsync(int id, LanguageDto updatedLanguage);
        //Task<bool> DeleteLanguageAsync(int id);
        //Task<List<LanguageDto>> GetLanguagesByCategoryIdAsync(int categoryId);

    }
}
