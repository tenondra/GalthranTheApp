using backend.Services.IndexingService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Index;

[Route("index")]
public class IndexController : BaseControllerV1
{
    private readonly IIndexingService _indexingService;

    public IndexController(IIndexingService indexingService)
    {
        _indexingService = indexingService;
    }

    [HttpPost]
    public IActionResult Index()
    {
        _indexingService.IndexDocument(@"C:\Users\onmal\Desktop\Heroes3_rules_rewrite_10.pdf");

        return Ok();
    }
}