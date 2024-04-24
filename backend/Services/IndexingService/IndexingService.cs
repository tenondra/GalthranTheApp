using backend.DTOs;
using backend.Qdrant;
using backend.Services.Chunking;
using backend.Services.Embedding;
using backend.Services.PdfReading;

namespace backend.Services.IndexingService;

public class IndexingService : IIndexingService
{
    private readonly IChunkingService _chunkingService;
    private readonly IPdfReadingService _pdfReadingService;
    private readonly IEmbeddingService _embeddingService;
    private readonly IQdrantService _qdrantService;

    private Guid _groupId;

    public IndexingService(
        IChunkingService chunkingService,
        IPdfReadingService pdfReadingService,
        IEmbeddingService embeddingService,
        IQdrantService qdrantService)
    {
        _chunkingService = chunkingService;
        _pdfReadingService = pdfReadingService;
        _embeddingService = embeddingService;
        _qdrantService = qdrantService;

        _groupId = new Guid();
    }

    public async void IndexDocument(string documentPath)
    {
        var documentPages = _pdfReadingService.ReadPdf(documentPath);
        List<List<string>> chunkedPages = [];
        chunkedPages
            .AddRange(documentPages
                .Select(page => _chunkingService.ChunkPage(page)));

        List<UpsertEmbeddingsData> data = [];
        foreach (var page in chunkedPages)
            data.AddRange(await ProcessPage(page));
        
        await _qdrantService.UpsertEmbeddingsAsync(data);
    }

    private async Task<IEnumerable<UpsertEmbeddingsData>> ProcessPage(List<string> page)
    {
        List<UpsertEmbeddingsData> data = [];
        foreach (var chunk in page)
            data.Add(await ProcessChunk(chunk));

        return data;
    }

    private async Task<UpsertEmbeddingsData> ProcessChunk(string chunk)
    {
        var embedding = await _embeddingService.GenerateEmbeddings(chunk);
        var embeddingVector = embedding.Data.First().Embedding.ToArray();
        var id = Guid.NewGuid();
        var gameDto = CreateGameDto(chunk, id, _groupId);
        return CreateEmbeddingData(embeddingVector, gameDto);
    }

    private static BoardGameDTO CreateGameDto(string text, Guid id, Guid groupId) => new()
    {
        Id = id,
        Name = "Heroes3",
        GroupId = groupId,
        Text = text
    };

    private static UpsertEmbeddingsData CreateEmbeddingData(float[] embedding, BoardGameDTO gameDto) =>
        new() { Embedding = embedding, GameDto = gameDto };
}