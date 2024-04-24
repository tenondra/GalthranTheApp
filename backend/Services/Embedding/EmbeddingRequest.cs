using System.Text.Json.Serialization;

namespace backend.Services.Embedding;

public record EmbeddingRequest()
{
    [JsonPropertyName("input")]
    public string Input { get; set; }
    
    [JsonPropertyName("model")]
    public string Model => "text-embedding-3-small";
};