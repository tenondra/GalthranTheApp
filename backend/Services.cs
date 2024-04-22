using backend.Controllers;
using backend.EmbeddingService;
using backend.Qdrant;

namespace backend;

public static class ServicesExtensions
{
    public static IServiceCollection AddProjectServices(
        this IServiceCollection services)
    {
        services.AddSingleton<IScannerController, ScannerController>();
        services.AddSingleton<IQdrantClientFactory, QdrantClientFactory>();
        services.AddSingleton<IQdrantService, QdrantService>();
        services.AddSingleton<IEmbeddingService, EmbeddingService.EmbeddingService>();
        services.AddSingleton<IKernelFactory, KernelFactory>();

        return services;
    }
    
    
}