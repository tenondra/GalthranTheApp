using backend.DTOs;

namespace backend.Qdrant;

public record UpsertEmbeddingsData()
{
    public float[] Embedding;
    public BoardGameDTO GameDto;
}