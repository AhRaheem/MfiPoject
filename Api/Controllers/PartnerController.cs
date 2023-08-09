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
    public class PartnerController : ControllerBase
    {
        public PartnerController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Data = new List<PartnerDto>();
            return Ok(Data);
        }
    }
}
