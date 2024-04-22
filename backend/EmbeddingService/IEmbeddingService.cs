namespace backend.EmbeddingService;

public interface IEmbeddingService
{
    public Task<EmbeddingResponse> GenerateEmbeddings(string text);
}