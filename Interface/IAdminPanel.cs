using TechSummary.DTOs.AdminPanel;

namespace TechSummary.Interface
{
    public interface IAdminPanel
    {
        Task<string> AddCategoryAsync(CategoryInpu input);
        Task<bool> UpdateCategoryAsync(UpdateCategoryInput input);
        Task<bool> DeleteCategoryAsync(int id);
        Task<List<CategoryDto>> GetAllCategoriesAsync();




        Task<bool> AddLanguageAsync(LanguageDto language);
        Task<bool> UpdateLanguageAsync(int id, LanguageDto updatedLanguage);
        Task<bool> DeleteLanguageAsync(int id);
        Task<List<LanguageDto>> GetLanguagesByCategoryIdAsync(int categoryId);
        
        
        
        Task<bool> AddTopicAsync(TopicDto topic);
        Task<bool> UpdateTopicAsync(int id, TopicDto updatedTopic);
        Task<bool> DeleteTopicAsync(int id);
        Task<List<TopicDto>> GetTopicsByLanguageIdAsync(int languageId);

       
        Task<bool> ApproveContentAsync(int contentId);
        Task<bool> DeleteContentAsync(int contentId);
        Task<List<ContentDto>> GetPendingContentsAsync();
        Task<ContentDto> GetContentByIdAsync(int contentId);
        Task<List<ContentDto>> GetContentsByTopicIdAsync(int topicId);

      
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<bool> BlockUserAsync(int userId);
        Task<bool> UnblockUserAsync(int userId);
    }
}
