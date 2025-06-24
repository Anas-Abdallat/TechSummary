using TechSummary.Interface;
using TechSummary.Models;

namespace TechSummary.Service
{
    public class AdminPanelService : IAdminPanel
    {
        private readonly TechSummaryContext _dbContext;

        public AdminPanelService(TechSummaryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> AddCategoryAsync(string name)
        {
            Category newCategory = new Category();
            _dbContext.Categories.Add(newCategory);
            return _dbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);

        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DTOs.AdminPanel.CategoryDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(int id, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
