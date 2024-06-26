using backend.Qdrant;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Qdrant;

[Route("qdrant")]
public class QdrantController : BaseControllerV1
{
    private readonly IQdrantService _qdrantService;

    public QdrantController(IQdrantService qdrantService)
    {
        _qdrantService = qdrantService;
    }
    
    [HttpPut("collections/create")]
    public IActionResult CreateCollection([FromBody] QdrantCollectionRequest request)
    {
        _qdrantService.CreateCollectionAsync(request.CollectionName);

        return Ok();
    }
    
    [HttpGet("collections/get")]
    public IActionResult GetCollection()
    {
        return Ok();
    }

    protected async Task<IActionResult> Search([FromBody] QdrantSearchRequest request)
    {
        string result;
        if (request.GroupId is not null)
            result = await _qdrantService.SearchCollectionAsync(request.Embedding, request.GroupId);
        else
            result = await _qdrantService.SearchCollectionAsync(request.Embedding);

        return Ok(result);
    }
}