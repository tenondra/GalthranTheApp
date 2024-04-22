using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Embeddings;

namespace backend.EmbeddingService;

public class EmbeddingService : IEmbeddingService
{
    private readonly Kernel _kernel;

    private ITextEmbeddingGenerationService EmbeddingGenerationService =>
        _kernel.GetRequiredService<ITextEmbeddingGenerationService>();

    public EmbeddingService(IKernelFactory kernelFactory)
    {
        _kernel = kernelFactory.CreateKernel();
    }

    public async Task<ReadOnlyMemory<float>> GenerateEmbeddings(string text)
    {
        var result = await EmbeddingGenerationService.GenerateEmbeddingsAsync(new List<string> { text });

        return result.First();
    }
}