using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSummary.DTOs.AdminPanel;
using TechSummary.Helper;
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
                Name = input.Name,
                Description = input.Description,
                Image = input.Image

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
        public async Task<string> UpdateCategoryAsync(UpdateCategoryInput input)
        {

            if (input.Id <= 0 || string.IsNullOrWhiteSpace(input.Name))
                return "invalid input";

            var category = await _dbContext.Categories.FindAsync(input.Id);
            if (category == null)
                return "No category with tis id ";
            category.Name = input.Name;
            category.Description = input.Description;
            category.Image = input.Image;
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            return "updated";
        }
        public async Task<bool> AddLanguageAsync(LanguageDto language)
        {
           LanguageValidator.Validate(language, _dbContext);
            if (language.Name == null)
                return false;
            var newLanguage = new Language
            {
                Name = language.Name,
                Description = language.Description ?? string.Empty,
                Image = language.Image ?? string.Empty,

            };
            _dbContext.Languages.Add(newLanguage);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddTopicAsync(TopicDto input)
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

        Task<bool> IAdminPanel.DeleteContentAsync(int contentId)
        {
            throw new NotImplementedException();
        }

        public async  Task<bool> DeleteLanguageAsync(int id)
        {
            var result = await _dbContext.Languages.FindAsync(id);
            if (result==null)
            {
                return false;
            }
            _dbContext.Languages.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteTopicAsync(int Id)
        {
            var result = await _dbContext.Topics.FindAsync(Id);
            if (result == null)
            {
                return false;
            }

            _dbContext.Topics.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserDto>>GetAllUsersAsync()
        {
            try
            {
                return await _dbContext.Users
                    .Select(u => new UserDto
                    {
                        Id = u.Id,
                        FullName = u.FullName,
                        Email = u.Email,
                        RoleId = u.RoleId,
                        IsActive = u.IsActive
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error retrieving users", ex);
            }
        }

        Task<ContentDto> IAdminPanel.GetContentByIdAsync(int contentId)
        {
            throw new NotImplementedException();
        }

        Task<List<ContentDto>> IAdminPanel.GetContentsByTopicIdAsync(int topicId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LanguageDto>> GetLanguagesByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        
            //var result = _dbContext.Languages
            //    .Where(l => l.CategoryId == categoryId)
            //    .Select(l => new LanguageDto
            //    {
            //        Id = l.Id,
            //        Name = l.Name,
            //        Description = l.Description,
            //        Image = l.Image
            //    })
            //    .ToListAsync();
        }

        Task<List<ContentDto>> IAdminPanel.GetPendingContentsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TopicDto>> GetTopicsByLanguageIdAsync(int languageId)
        {
            var topics = await _dbContext.Topics
                .Where(t => t.LanguageId == languageId)
                .Select(t => new TopicDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description
                })
                .ToListAsync();

            return topics;
        }


        public async Task<UserDto> GetUserByIdAsync(int userId)
{
    var user = await _dbContext.Users
        .Where(u => u.Id == userId)
        .Select(u => new UserDto
        {
            Id = u.Id,
            FullName = u.FullName,
            Email = u.Email,
            RoleId = u.RoleId,
            IsActive = u.IsActive
        })
        .FirstOrDefaultAsync();

    return user!;
}


       public async Task<bool> UnblockUserAsync(UserDto input)
        {
           
            if (input.Id <= 0)
                return false;

            var user = await _dbContext.Users.FindAsync(input.Id);
            if (user == null)
                return false;
            
            if (user.RoleId == 1)
                return false;


            user.IsActive = true;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return true;
       

        }

        public async Task<string> UpdateLanguageAsync(LanguageDto input)
        {
            try
            {
                if (input.Id <= 0 || string.IsNullOrWhiteSpace(input.Name))
                    return "Invalid input";

                var language = await _dbContext.Languages.FindAsync(input.Id);
                if (language == null)
                    return "No language with this ID";

                language.Name = input.Name;
                language.Description = input.Description ?? string.Empty;
                language.Image = input.Image ?? language.Image;
                language.UpdatedDate = DateTime.Now;
                language.UpdatedBy = 1;

                _dbContext.Languages.Update(language);
                await _dbContext.SaveChangesAsync();

                return "Updated successfully";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        public async Task<string> UpdateTopicAsync(TopicDto input)
        {
            try
            {
                if (input.Id <= 0 || string.IsNullOrWhiteSpace(input.Name))
                    return "Invalid input";

                var Topic = await _dbContext.Topics.FindAsync(input.Id);
                if (Topic == null)
                    return "No language with this ID";

                Topic.Name = input.Name;
                Topic.Description = input.Description;
                

                _dbContext.Topics.Update(Topic);
                await _dbContext.SaveChangesAsync();

                return "Updated successfully";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
