using Api.Enums;
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
        public readonly IGalleryService _GalleryService;
        public GalleryController(IGalleryService galleryService)
        {
            _GalleryService = galleryService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<GalleryDto>> Get(string Id)
        {
            var Data = await _GalleryService.GetById(Id);
            if(Data is null)
                return NotFound();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GalleryDto>>> GetAll(DateTime? FromDate, DateTime? ToDate, string q = "", SortByType SortByTypeFlag = 0, int Page = 1, int Size = 9)
        {
            var Data = (await _GalleryService.GetAll(FromDate,ToDate,q,Page,Size)).Items.ToList();
            if (SortByTypeFlag == SortByType.Newest)
                Data = Data.OrderByDescending(x => x.CreatedOn).ToList();
            if (SortByTypeFlag == SortByType.Oldest)
                Data = Data.OrderBy(x => x.CreatedOn).ToList();
            return Ok(Data);
        }
    }
}
