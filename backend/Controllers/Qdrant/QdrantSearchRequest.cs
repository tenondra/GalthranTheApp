namespace backend.Controllers.Qdrant;

public record QdrantSearchRequest()
{
    public float[] Embedding { get; set; }
    public string? GroupId { get; set; }
}