using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using IronOcr;
using System.Drawing;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class ConvertController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            if (file.Length == 0)
            {
                return NotFound();
            }
            else
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    using (var img = Image.FromStream(memoryStream))
                    {
                        var Result = new IronOcr.IronTesseract().Read(img);
                        return new JsonResult(Result);
                    }
                }
            }
        }
    }
}
