namespace backend.Services.Embedding;

public interface IOpenAiClient
{
    public Task<EmbeddingResponse> CreateEmbeddingAsync(EmbeddingRequest request);
}