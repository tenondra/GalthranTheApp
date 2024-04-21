using backend.Controllers;
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

        return services;
    }
    
    
}