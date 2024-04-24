namespace backend.Controllers.Qdrant;

public record QdrantCollectionRequest
{
    public string CollectionName { get; set; }
}