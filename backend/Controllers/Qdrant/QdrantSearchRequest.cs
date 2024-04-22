namespace backend.Controllers;

public record QdrantSearchRequest()
{
    public float[] Embedding { get; set; }
    public string? GroupId { get; set; }
}