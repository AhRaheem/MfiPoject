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

        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {
            var Data = new NewsDto();
            return Ok(Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Data = new List<NewsDto>();
            return Ok(Data);
        }
    }
}
