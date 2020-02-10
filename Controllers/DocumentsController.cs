using System.IO;
using System.Threading.Tasks;
using DevExpress.XtraRichEdit;
using Microsoft.AspNetCore.Mvc;

namespace WebHtmlEditor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string htmlText)
        {
            var server = new RichEditDocumentServer();

            server.LoadDocument(@"C:\Users\honay\Desktop\Doc1.rtf", DocumentFormat.Rtf);
            var bm = server.Document.Bookmarks["mainContent"];
            server.Document.InsertHtmlText(bm.Range.Start, htmlText);
            
            var stream = new MemoryStream();
            server.ExportToPdf(stream);
            stream.Position = 0;
            
            Response.Headers.Add("Content-Disposition", "inline; filename*=result.pdf");
            return new FileStreamResult(stream,"application/pdf");
        }
    }
}