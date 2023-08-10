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
        public NewsController()
        {
        }

        [HttpGet("Get")]
        public async Task<ActionResult<NewsDto>> Get(string Id)
        {
            var Data = new NewsDto();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<NewsDto>>> GetAll(int Page)
        {
            var Data = new List<NewsDto>();
            return Ok(Data);
        }
    }
}
