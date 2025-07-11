using Microsoft.AspNetCore.Mvc;
using TechSummary.DTOs.AdminPanel;
using TechSummary.Interface;

[ApiController]
[Route("api/[controller]")]
public class AdminPanelController : ControllerBase
{
    private readonly IAdminPanel _adminPanel;

    public AdminPanelController(IAdminPanel appService)
    {
        _adminPanel = appService;
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory(CategoryInpu input)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(input.Name))
                return BadRequest("Category name is required.");

            var result = await _adminPanel.AddCategoryAsync(input);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {

        try
        {
            var result = await _adminPanel.DeleteCategoryAsync(id);
            if (result)
                return Ok("Category deleted successfully.");
            else
                return NotFound("Category not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _adminPanel.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryInput input)
    {
        try
        {
            if (input.Id <= 0 || string.IsNullOrWhiteSpace(input.Name))
                return BadRequest("Invalid category data.");
            var result = await _adminPanel.UpdateCategoryAsync(input);
            if (result == "updated")
                return Ok("Category updated successfully.");
            else
                return NotFound("Category not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _adminPanel.GetUserByIdAsync(userId);

        if (user == null)
            return NotFound("User not found.");

        return Ok(user);
    }

    [HttpGet("topics/by-language/{languageId}")]
    public async Task<IActionResult> GetTopicsByLanguageId(int languageId)
    {
        var topics = await _adminPanel.GetTopicsByLanguageIdAsync(languageId);

        if (topics == null || !topics.Any())
            return NotFound("No topics found for this language.");

        return Ok(topics);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateLanguageAsync(LanguageDto input)
    {
        try
        {
            var result = await _adminPanel.UpdateLanguageAsync(input);

            return result switch

            {
                "Updated successfully" => Ok(result),
                "No language with this ID" => NotFound(result),
                "Invalid input" => BadRequest(result),
                _ when result.StartsWith("Error:") => StatusCode(500, result),
                _ => StatusCode(500, "Unknown error occurred")
            };
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("DeleteLanguage/{id}")]

    public async Task<IActionResult> DeleteLanguageAsync(int id)
    {
        try
        {
            var result = await _adminPanel.DeleteLanguageAsync(id);
            if (result)
                return Ok("Language deleted successfully.");
            else
                return NotFound("Language not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        try
        {
            var users = await _adminPanel.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("[action]/{Id}")]
    public async Task<IActionResult> DeleteTopicAsync(int Id)
    {
        try
        {
            var result = await _adminPanel.DeleteTopicAsync(Id);

            if (!result)
                return NotFound($"No topic found with ID = {Id}");

            return Ok("Topic deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult>AddLanguageAsync(LanguageDto language)
    {
        try
        {
            if (language == null)
                return BadRequest("Language data is required.");
            var result = await _adminPanel.AddLanguageAsync(language);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddTopicAsync(TopicDto topic)
    {
        try
        {
            if (topic == null || string.IsNullOrWhiteSpace(topic.Name))
                return BadRequest("Topic data is required.");
            var result = await _adminPanel.AddTopicAsync(topic);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is required.");
            var result = await _adminPanel.UploadFile(file);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


}