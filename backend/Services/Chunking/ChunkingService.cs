using System.Text.RegularExpressions;

namespace backend.Services.Chunking;

public partial class ChunkingService : IChunkingService
{
    public ChunkingService()
    {
    }

    public List<string> ChunkPage(string page)
    {
        var clearedPage = ClearPage(page);
        var splitPage = clearedPage.Split(".");

        List<string> pageChunks = [];
        for (int i = 0; i < splitPage.Length; i += 3)
        {
            var lowerBoundary = Math.Max(0, i - 1);
            var upperBoundary = Math.Min(splitPage.Length, i + 3);
            var chunk = splitPage[lowerBoundary..upperBoundary];
            var paragraph = String.Join(' ', chunk);
            pageChunks.Add(paragraph);
        }

        return pageChunks;
    }

    private static string ClearPage(string page) => MyRegex().Replace(page, ".");

    [GeneratedRegex("[.]{2,}")]
    private static partial Regex MyRegex();
}