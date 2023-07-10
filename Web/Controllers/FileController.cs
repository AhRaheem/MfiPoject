using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using System.IO;

namespace Web.Controllers
{
	public class FileController : Controller
    {
        public readonly IFileService _FileService;

        public FileController(IFileService FileService)
        {
            _FileService = FileService;
        }

        public async Task<IActionResult> GetImage(string Id, int Width, int Height)
        {
			var ImgDto = await _FileService.GetById(Id);
            if(ImgDto is null)
                return NotFound();
            var ImageBytes = await _FileService.GetImage(ImgDto, Width, Height);
            if (ImageBytes is null)
                return NotFound();
            return File(ImageBytes, "application/octet-stream");
        }
    }
}
