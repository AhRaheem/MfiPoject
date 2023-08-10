using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Partner;
using Infrastructure.Dtos.ProfileInfo;
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

        [HttpGet("Get")]
        public async Task<ActionResult<PartnerDto>> Get(string Id)
        {
            var Data = new PartnerDto();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PartnerDto>>> GetAll(int Page)
        {
            var Data = new List<PartnerDto>();
            return Ok(Data);
        }
    }
}
