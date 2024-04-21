using Qdrant.Client;
using Qdrant.Client.Grpc;

namespace backend.Qdrant;

public class QdrantService : IQdrantService
{
    private readonly QdrantClient qdrantClient;

    public QdrantService(IQdrantClientFactory clientFactory)
    {
        qdrantClient = clientFactory.GetClient();
    }

    public async void CreateCollection(string collectionName)
    {
        await qdrantClient.CreateCollectionAsync(
            collectionName: collectionName,
            vectorsConfig: SetupParams());
    }

    private static VectorParams SetupParams() => new() { Size = 1536, Distance = Distance.Cosine };

    public async void UpsertPoint(string collectionName, float[] embedding)
    {
        qdrantClient.UpsertAsync(collectionName, new []{ new PointStruct() {Id = new PointId(), Payload = {  }}})
    }
}