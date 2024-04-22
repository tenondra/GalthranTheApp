using backend.EmbeddingService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("embedding")]
public class EmbeddingController : BaseControllerV1
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