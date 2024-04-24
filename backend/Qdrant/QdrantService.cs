using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using backend.DTOs;
using Google.Protobuf.Collections;
using Qdrant.Client;
using Qdrant.Client.Grpc;

namespace backend.Qdrant;

public class QdrantService : IQdrantService
{
    private const string CollectionName = "test_collection";
    private readonly QdrantClient _qdrantClient;

    public QdrantService(IQdrantClientFactory clientFactory)
    {
        _qdrantClient = clientFactory.GetClient();
    }

    // https://qdrant.tech/documentation/guides/optimize/
    public async void CreateCollectionAsync(string collectionName)
    {
        await _qdrantClient.CreateCollectionAsync(
            collectionName: collectionName,
            vectorsConfig: SetupParams());
    }

    public async Task<IEnumerable<string>> ListCollectionsAsync() => await _qdrantClient.ListCollectionsAsync();

    private static VectorParams SetupParams() => new() { Size = 1536, Distance = Distance.Cosine };

    public async void UpsertEmbeddingsAsync(IEnumerable<UpsertEmbeddingsData> data)
    {
        await _qdrantClient.UpsertAsync(
            CollectionName,
            points: data.Select(item => PointStructFromData(item)).ToArray());
    }

    public async Task<string> SearchCollectionAsync(float[] embedding)
    {
        var points = await _qdrantClient.SearchAsync(CollectionName, embedding);
        var foundValue = points
            .OrderBy(point => point.Score)
            .First()
            .Payload
            .TryGetValue("text", out var result);

        if (!foundValue)
            throw new Exception("Could not find value.");

        return result?.StringValue ?? "EMPTY";
    }

    public async Task<string> SearchCollectionAsync(float[] embedding, string groupId)
    {
        var points = await _qdrantClient.SearchAsync(
            CollectionName,
            embedding,
            filter: new Filter
                { Must = { new Condition { Field = { Key = "group_id", Match = new Match { Keyword = groupId } } } } });
        
        var foundValue = points
            .OrderBy(point => point.Score)
            .First()
            .Payload
            .TryGetValue("text", out var result);

        if (!foundValue)
            throw new Exception("Could not find value.");

        return result?.StringValue ?? "EMPTY";
    }

    private PointStruct PointStructFromData(UpsertEmbeddingsData item) => new()
    {
        Id = item.GameDto.Id,
        Vectors = new Vectors(item.Embedding),
        Payload = { BoardGameDTO.ToPayloadStructure(item.GameDto) }
    };
}