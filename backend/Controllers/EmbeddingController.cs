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
    public async Task<IActionResult> CreateEmbedding([FromBody] EmbeddingRequestModel model)
    {
       var result = await _embeddingService.GenerateEmbeddings(model.Text);

       return Ok(result.Data.First().Embedding);
    }
}