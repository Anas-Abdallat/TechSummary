using Microsoft.AspNetCore.Mvc;
using TechSummary.Interface;

namespace TechSummary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentFilterController : ControllerBase
    {
        private readonly IContentFilterService _filterService;

        public ContentFilterController(IContentFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet("by-views")]
        public async Task<IActionResult> GetByMostViewed()
        {
            var result = await _filterService.GetByMostViewedAsync();
            return Ok(result);
        }

        [HttpGet("by-date")]
        public async Task<IActionResult> GetByNewest()
        {
            var result = await _filterService.GetByNewestAsync();
            return Ok(result);
        }

        [HttpGet("by-rating")]
        public async Task<IActionResult> GetByTopRated()
        {
            var result = await _filterService.GetByTopRatedAsync();
            return Ok(result);
        }
    }
}
