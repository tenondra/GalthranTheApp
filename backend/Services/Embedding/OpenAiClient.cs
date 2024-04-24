using System.Text;
using System.Text.Json;

namespace backend.Services.Embedding;

public class OpenAiClient : IOpenAiClient
{
    private const string EmbeddingEndpoint = "embeddings";

    private readonly HttpClient _httpClient;

    private string EmbeddingUrl => $"{_httpClient.BaseAddress}/{EmbeddingEndpoint}";
    
    public OpenAiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EmbeddingResponse> CreateEmbeddingAsync(EmbeddingRequest request)
    {
        var serializedBody = JsonSerializer.Serialize(request);
        var content = new StringContent(serializedBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(EmbeddingUrl, content);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<EmbeddingResponse>(result);

        if (deserializedResponse is null)
            throw new Exception("");
        
        return deserializedResponse;
    }
    
}