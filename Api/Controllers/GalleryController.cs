using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.Achievement;
using Infrastructure.Dtos.Gallery;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        public GalleryController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {
            var Data = new GalleryDto();
            return Ok(Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Data = new List<GalleryDto>();
            return Ok(Data);
        }
    }
}
