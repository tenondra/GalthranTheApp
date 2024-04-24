namespace backend.Qdrant;

public interface IQdrantService
{
    public Task CreateCollectionAsync(string collectionName);
    public Task<IEnumerable<string>> ListCollectionsAsync();
    public Task UpsertEmbeddingsAsync(IEnumerable<UpsertEmbeddingsData> data);
    public Task<string> SearchCollectionAsync(float[] embedding);
    public Task<string> SearchCollectionAsync(float[] embedding, string groupId);
}