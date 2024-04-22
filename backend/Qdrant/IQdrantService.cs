namespace backend.Qdrant;

public interface IQdrantService
{
    public void CreateCollection(string collectionName);
}