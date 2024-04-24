namespace backend.Services.Embedding;

public interface IEmbeddingService
{
    public Task<EmbeddingResponse> GenerateEmbeddings(string text);
}