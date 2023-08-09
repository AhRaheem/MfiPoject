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
        public AboutUsController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("");
        }
    }
}
