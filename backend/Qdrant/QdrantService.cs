using Qdrant.Client;
using Qdrant.Client.Grpc;

namespace backend.Qdrant;

public class QdrantService : IQdrantService
{
    private readonly QdrantClient _qdrantClient;

    public QdrantService(IQdrantClientFactory clientFactory)
    {
        _qdrantClient = clientFactory.GetClient();
    }

    public async void CreateCollection(string collectionName)
    {
        await _qdrantClient.CreateCollectionAsync(
            collectionName: collectionName,
            vectorsConfig: SetupParams());
    }

    private static VectorParams SetupParams() => new() { Size = 1536, Distance = Distance.Cosine };

    public async void UpsertPoint(string collectionName, float[] embedding)
    {
        await _qdrantClient.UpsertAsync(collectionName, new[] { new PointStruct() { Id = new PointId(), Payload = { {"value", "value"} } } });
    }
}