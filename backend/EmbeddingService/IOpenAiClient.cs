namespace backend.EmbeddingService;

public interface IOpenAiClient
{
    public Task<EmbeddingResponse> CreateEmbeddingAsync(EmbeddingRequest request);
}