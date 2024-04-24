using Docnet.Core;
using Docnet.Core.Models;

namespace backend.Services.PdfReading;

public class PdfReadingService : IPdfReadingService
{
    public IDocLib DocNet { get; }
    
    public PdfReadingService()
    {
        DocNet = DocLib.Instance;
    }
    public IEnumerable<string> ReadPdf(string documentPath)
    {
        using var docReader = DocNet.GetDocReader(documentPath, new PageDimensions(1080, 1920));

        for (int pageIndex = 0; pageIndex < docReader.GetPageCount(); pageIndex++)
        {
            var page = docReader.GetPageReader(pageIndex);
            yield return page.GetText();
            // var b = page.GetImage();
        }
    }
}