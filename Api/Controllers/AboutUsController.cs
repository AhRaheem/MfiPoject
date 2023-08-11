using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        public readonly IAboutUsService _AboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            _AboutUsService = aboutUsService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<AboutUsDto>> Get()
        {
            var Data = await _AboutUsService.GetUpdateInfo();
            return Ok(Data);
        }
    }
}
