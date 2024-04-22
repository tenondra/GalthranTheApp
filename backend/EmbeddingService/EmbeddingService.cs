using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Embeddings;

namespace backend.EmbeddingService;

public class EmbeddingService
{
    private readonly Kernel _kernel;

    private ITextEmbeddingGenerationService EmbeddingGenerationService =>
        _kernel.GetRequiredService<ITextEmbeddingGenerationService>();


    public EmbeddingService(IConfiguration configuration)
    {
        var kernelBuilder = Kernel
            .CreateBuilder()
            .WithCustomOpenAiEmbeddingModel(configuration);

        _kernel = kernelBuilder.Build();
    }

    public async Task<ReadOnlyMemory<float>> GenerateEmbeddings(string text)
    {
        var result = await EmbeddingGenerationService.GenerateEmbeddingsAsync(new List<string> { text });

        return result.First();
    }
}