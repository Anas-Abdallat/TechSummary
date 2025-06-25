using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using TechSummary.DTOs.AdminPanel;
using TechSummary.Interface;
using TechSummary.Models;
using TechSummary.Validators;

namespace TechSummary.Service
{
    public class AdminPanelService : IAdminPanel
    {
        private readonly TechSummaryContext _dbContext;

        public  AdminPanelService(TechSummaryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> AddCategoryAsync(CategoryInpu input)
        {
            CategoryInputValidator.Validate(input, _dbContext);
            if (input.Name == null)
                return "Category already exists.";

            var newCategory = new Category
            {
                Name = input.Name
            };

            _dbContext.Categories.Add(newCategory);
            await _dbContext.SaveChangesAsync();

            return "Good News";
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return false; 
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<DTOs.AdminPanel.CategoryDto>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories
                .Select(c => new DTOs.AdminPanel.CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
        public async Task<bool> UpdateCategoryAsync(UpdateCategoryInput input)
        {
            var  Category = await _dbContext.Categories.FindAsync(input.Id);
            if (Category == null)
            { 
            return false;
            }
            Category.Name = input.Name;
            _dbContext.Categories.Update(Category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

        Task<bool> IAdminPanel.AddLanguageAsync(LanguageDto language)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.AddTopicAsync(TopicDto topic)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.ApproveContentAsync(int contentId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.BlockUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.DeleteContentAsync(int contentId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.DeleteLanguageAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.DeleteTopicAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<CategoryDto>> IAdminPanel.GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<UserDto>> IAdminPanel.GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        Task<ContentDto> IAdminPanel.GetContentByIdAsync(int contentId)
        {
            throw new NotImplementedException();
        }

        Task<List<ContentDto>> IAdminPanel.GetContentsByTopicIdAsync(int topicId)
        {
            throw new NotImplementedException();
        }

        Task<List<LanguageDto>> IAdminPanel.GetLanguagesByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        Task<List<ContentDto>> IAdminPanel.GetPendingContentsAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<TopicDto>> IAdminPanel.GetTopicsByLanguageIdAsync(int languageId)
        {
            throw new NotImplementedException();
        }

        Task<UserDto> IAdminPanel.GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.UnblockUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.UpdateCategoryAsync(UpdateCategoryInput input)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.UpdateLanguageAsync(int id, LanguageDto updatedLanguage)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdminPanel.UpdateTopicAsync(int id, TopicDto updatedTopic)
        {
            throw new NotImplementedException();
        }
    }
}
