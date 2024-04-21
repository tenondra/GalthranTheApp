using Qdrant.Client;

namespace backend.Qdrant;

public class QdrantClientFactory(IConfiguration configuration) : IQdrantClientFactory
{
    private QdrantClient? _qdrantClient;

    public QdrantClient GetClient() => _qdrantClient ?? ConstructAndAssignClient();
    
    private QdrantClient ConstructAndAssignClient()
    {
        var client = new QdrantClient(
            address: QdrantApiUrl,
            apiKey: QdrantApiKey
            );

        _qdrantClient = client;
        
        return client;
    }

    private Uri QdrantApiUrl => new Uri(configuration["Qdrant:ApiUrl"] ?? "");

    private string QdrantApiKey => configuration["Qdrant:ApiKey"] ?? "";
}