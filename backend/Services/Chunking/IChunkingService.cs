namespace backend.Services.Chunking;

public interface IChunkingService
{
    public List<string> ChunkPage(string page);
}