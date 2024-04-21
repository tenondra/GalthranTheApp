using Qdrant.Client;

namespace backend.Qdrant;

public interface IQdrantClientFactory
{
    public QdrantClient GetClient();
}