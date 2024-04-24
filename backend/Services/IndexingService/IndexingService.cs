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
    }

    public void IndexDocument(string documentPath)
    {
        var documentPages = _pdfReadingService.ReadPdf(documentPath);
        List<List<string>> chunkedPages = [];
        chunkedPages
            .AddRange(documentPages
                .Select(page => _chunkingService.ChunkPage(page)));

        foreach (var page in chunkedPages)
            ProcessPage(page);
    }

    private void ProcessPage(List<string> page)
    {
        foreach (var chunk in page)
            ProcessChunk(chunk);
    }

    private async void ProcessChunk(string chunk)
    {
        var embedding = await _embeddingService.GenerateEmbeddings(chunk);
        var embeddingVector = embedding.Data.First().Embedding.ToArray();
        var gameDto = CreateGameDto(chunk);
        var embeddingData = CreateEmbeddingData(embeddingVector, gameDto);
        
        _qdrantService.UpsertEmbeddingsAsync(new[] { embeddingData });
    }

    private static BoardGameDTO CreateGameDto(string text) => new()
    {
        Name = "Heroes3",
        GroupId = Guid.NewGuid(),
        Text = text
    };

    private static UpsertEmbeddingsData CreateEmbeddingData(float[] embedding, BoardGameDTO gameDto) =>
        new() { Embedding = embedding, GameDto = gameDto };
}