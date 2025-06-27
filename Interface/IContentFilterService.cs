using TechSummary.DTOs.ContentFilterDto.Request;

namespace TechSummary.Interface
{
    public interface IContentFilterService
    {
        Task<IEnumerable<ContentFilterDto>> GetByMostViewedAsync();
        Task<IEnumerable<ContentFilterDto>> GetByNewestAsync();
        Task<IEnumerable<ContentFilterDto>> GetByTopRatedAsync();
    }
}
