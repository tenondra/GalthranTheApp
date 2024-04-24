using backend.Qdrant;
using backend.Services.Embedding;

namespace backend.Services;

public class SearchService : ISearchService
{
    private readonly IQdrantService _qdrantService;
    private readonly IEmbeddingService _embeddingService;

    public SearchService(IQdrantService qdrantService, IEmbeddingService embeddingService)
    {
        _qdrantService = qdrantService;
        _embeddingService = embeddingService;
    }
    
    public async Task<string> Search(string text)
    {
        var embeddingResult = await _embeddingService.GenerateEmbeddings(text);
        var embedding = embeddingResult.Data.First().Embedding.ToArray();
        
        var searchResult = await _qdrantService.SearchCollectionAsync(embedding);

        return searchResult;
    }
}