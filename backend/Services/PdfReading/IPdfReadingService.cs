namespace backend.Services.PdfReading;

public interface IPdfReadingService
{
    public IEnumerable<string> ReadPdf(string documentPath);
}