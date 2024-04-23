using backend.Services.PdfReading;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Index;

[Route("index")]
public class IndexController : BaseControllerV1
{
    private readonly IPdfReadingService _pdfReadingService;

    public IndexController(IPdfReadingService pdfReadingService)
    {
        _pdfReadingService = pdfReadingService;
    }

    [HttpPost]
    public IActionResult Index()
    {
        _pdfReadingService.ReadPdf(@"C:\Users\onmal\Desktop\Heroes3_rules_rewrite_10.pdf");

        return Ok();
    }
}