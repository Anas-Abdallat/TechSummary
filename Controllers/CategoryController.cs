using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSummary.Interface;

namespace TechSummary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
            => Ok(await _categoryService.GetAllCategoriesAsync());

        [HttpGet("languages")]
        public async Task<IActionResult> GetLanguages()
            => Ok(await _categoryService.GetLanguagesAsync());

        [HttpGet("topics")]
        public async Task<IActionResult> GetTopics()
            => Ok(await _categoryService.GetTopicsAsync());

        [HttpGet("topic-details/{id}")]
        public async Task<IActionResult> GetTopicDetails(int id)
            => Ok(await _categoryService.GetTopicDetailsAsync(id));

        [HttpGet("contents")]
        public async Task<IActionResult> GetAllContents()
            => Ok(await _categoryService.GetAllContentsAsync());

        [HttpGet("resources")]
        public async Task<IActionResult> GetResources()
            => Ok(await _categoryService.GetResourcesAsync());
    }

}
