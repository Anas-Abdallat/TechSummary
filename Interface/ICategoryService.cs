using TechSummary.DTOs.AllCategoryDTO;

namespace TechSummary.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<IEnumerable<LanguageDto>> GetLanguagesAsync();
        Task<IEnumerable<TopicDto>> GetTopicsAsync();
        Task<TopicDetailsDto> GetTopicDetailsAsync(int topicId);
        Task<IEnumerable<ContentDto>> GetAllContentsAsync();
        Task<IEnumerable<ResourceDto>> GetResourcesAsync();
    }

}
