namespace backend.Types;

public record Embedding
{
    public float[] Vector { get; set; }
    public int Dimensions { get; init; } = 1536;
}