using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.Achievement;
using Infrastructure.Dtos.Gallery;
using Infrastructure.Dtos.News;
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

        [HttpGet("Get")]
        public async Task<ActionResult<GalleryDto>> Get(string Id)
        {
            var Data = new GalleryDto();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GalleryDto>>> GetAll(int Page)
        {
            var Data = new List<GalleryDto>();
            return Ok(Data);
        }
    }
}
