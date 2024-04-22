using backend.EmbeddingService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/embedding")]
public class EmbeddingController : Controller
{
    private readonly IEmbeddingService _embeddingService;

    public EmbeddingController(IEmbeddingService embeddingService)
    {
        _embeddingService = embeddingService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateEmbedding([FromBody] string text)
    {
        var result = await _embeddingService.GenerateEmbeddings(text);

        return Ok(result);
    }
}