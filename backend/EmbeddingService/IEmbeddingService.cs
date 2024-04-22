namespace backend.EmbeddingService;

public interface IEmbeddingService
{
    public Task<ReadOnlyMemory<float>> GenerateEmbeddings(string text);
}