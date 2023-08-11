using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Partner;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public readonly INewsService _NewsService;
        public NewsController(INewsService newsService)
        {
            _NewsService = newsService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<NewsDto>> Get(string Id)
        {
            var Data = await _NewsService.GetById(Id);
            if(Data is null)
                return NotFound();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<NewsDto>>> GetAll(int Page=1)
        {
            var Data = await _NewsService.GetAll(page:Page,size:6);
            return Ok(Data);
        }
    }
}
