using System.Text.Json.Serialization;

namespace backend.EmbeddingService;

public record EmbeddingRequest()
{
    [JsonPropertyName("input")]
    public string Input { get; set; }
    
    [JsonPropertyName("model")]
    public string Model => "text-embedding-3-small";
};