using Microsoft.SemanticKernel;

namespace backend.EmbeddingService;

public static class KernelExtensions
{
    public static IKernelBuilder WithCustomOpenAiEmbeddingModel(this IKernelBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddOpenAITextEmbeddingGeneration(configuration.EmbeddingModel(), configuration.EmbeddingApiKey());
        return builder;
    }

    private static string EmbeddingApiKey(this IConfiguration configuration) => configuration["Embedding:ApiKey"] ?? "";
    private static string EmbeddingModel(this IConfiguration configuration) => configuration["Embedding:Model"] ?? "";
}