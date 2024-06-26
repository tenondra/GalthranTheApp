using System.Net.Http.Headers;
using backend.Qdrant;
using backend.Services;
using backend.Services.Embedding;
using backend.Services.Kernel;
using backend.Services.PdfReading;

namespace backend;

public static class ServicesExtensions
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddLogging();

        services.AddSingleton<IQdrantClientFactory, QdrantClientFactory>();
        services.AddSingleton<IQdrantService, QdrantService>();
        services.AddSingleton<IEmbeddingService, EmbeddingService>();
        services.AddSingleton<IKernelFactory, KernelFactory>();
        services.AddSingleton<IOpenAiClient, OpenAiClient>();
        services.AddSingleton<ISearchService, SearchService>();
        services.AddSingleton<IPdfReadingService, PdfReadingService>();
        
        return services;
    }

    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IOpenAiClient, OpenAiClient>(client =>
        {
            client.BaseAddress = new Uri(configuration["Embedding:APIUrl"]);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", configuration["Embedding:APIKey"]);
        });

        return services;
    }    
    

}