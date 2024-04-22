namespace backend.EmbeddingService;

public class EmbeddingService : IEmbeddingService
{
    private readonly IOpenAiClient _openAiClient;

    // private ITextEmbeddingGenerationService EmbeddingGenerationService =>
    //     _kernel.GetRequiredService<ITextEmbeddingGenerationService>();

    public EmbeddingService(IOpenAiClient openAiClient)
    {
        _openAiClient = openAiClient;
    }

    public async Task<EmbeddingResponse> GenerateEmbeddings(string text)
    {
        var request = CreateRequest(text);
        var result = await _openAiClient.CreateEmbeddingAsync(request);

        return result;
    }

    private EmbeddingRequest CreateRequest(string text) => new() { Input = text };
}