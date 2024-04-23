using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Search;

[Route("search")]
public class SearchController : BaseControllerV1
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Search([FromBody] SearchRequest request)
    {
        var result = await _searchService.Search(request.Text);

        return Ok(result);
    }
}