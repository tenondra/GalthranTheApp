namespace backend.Qdrant;

public interface IQdrantService
{
    public void CreateCollectionAsync(string collectionName);
    public Task<IEnumerable<string>> ListCollectionsAsync();
    public void UpsertEmbeddingsAsync(IEnumerable<UpsertEmbeddingsData> data);
    public Task<string> SearchCollectionAsync(float[] embedding);
    public Task<string> SearchCollectionAsync(float[] embedding, string groupId);
}