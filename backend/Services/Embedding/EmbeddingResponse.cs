using System.Text.Json.Serialization;

namespace backend.Services.Embedding;

public record EmbeddingResponseData
{
    [JsonPropertyName("embedding")]
    public List<float> Embedding { get; set; }
}

public record EmbeddingResponse
{
    [JsonPropertyName("data")]
    public List<EmbeddingResponseData> Data { get; set; }
    
    [JsonPropertyName("model")]
    public string Model { get; set; }
}