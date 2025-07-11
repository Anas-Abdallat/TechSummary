using Microsoft.AspNetCore.Mvc;
using TechSummary.DTOs.AdminPanel;
using TechSummary.Models;

namespace TechSummary.Interface
{
    public interface IAdminPanel
    {
        Task<string> AddCategoryAsync(CategoryInpu input);
        Task<string> UpdateCategoryAsync(UpdateCategoryInput input);
        Task<List<CategoryDto>> GetAllCategoriesAsync();


        Task<bool> AddLanguageAsync(LanguageDto language);
        Task<string> UpdateLanguageAsync(LanguageDto input);
        Task<bool> DeleteLanguageAsync(int id);
        Task<List<LanguageDto>> GetLanguagesByCategoryIdAsync(int categoryId);  
        
        Task<String> AddTopicAsync(TopicDto topic);
        Task<string> UpdateTopicAsync(TopicDto input);
        Task<bool> DeleteTopicAsync(int Id);
        Task<List<TopicDto>> GetTopicsByLanguageIdAsync(int languageId);

        Task<bool> ApproveContentAsync(int contentId);
        Task<bool> DeleteContentAsync(int contentId);
        Task<List<ContentDto>> GetPendingContentsAsync();
        Task<ContentDto> GetContentByIdAsync(int contentId);
        Task<List<ContentDto>> GetContentsByTopicIdAsync(int topicId);

        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<bool> BlockUserAsync(int userId);
        Task<bool> UnblockUserAsync (UserDto input);
        Task<bool> DeleteCategoryAsync(int id);
        Task<IActionResult> UploadFile(IFormFile file);
    }
}
