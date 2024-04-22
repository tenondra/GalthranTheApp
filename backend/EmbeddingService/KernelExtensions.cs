using Microsoft.KernelMemory;
using Microsoft.SemanticKernel;

namespace backend.EmbeddingService;

public static class KernelExtensions
{
    public static IKernelBuilder WithCustomOpenAiEmbeddingModel(this IKernelBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddOpenAITextEmbeddingGeneration(configuration.EmbeddingModel(), configuration.EmbeddingApiKey());
        
        var openAiConfig = SetupOpenAiConfig();
        builder.Services.AddOpenAITextEmbeddingGeneration(openAiConfig);
        return builder;
    }

    private static OpenAIConfig SetupOpenAiConfig()
    {
        var config = new OpenAIConfig();
        
        new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build()
            .BindSection("Embedding", config);

        return config;
    }
    private static string EmbeddingApiKey(this IConfiguration configuration) => configuration["Embedding:ApiKey"] ?? "";
    private static string EmbeddingModel(this IConfiguration configuration) => configuration["Embedding:Model"] ?? "";
}