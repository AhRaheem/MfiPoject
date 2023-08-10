using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.RelatedWebsite;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedWebsiteController : ControllerBase
    {
        public RelatedWebsiteController()
        {
        }

        [HttpGet("Get")]
        public async Task<ActionResult<RelatedWebsiteDto>> Get(string Id)
        {
            var Data = new RelatedWebsiteDto();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RelatedWebsiteDto>>> GetAll(int Page = 0)
        {
            var Data = new List<RelatedWebsiteDto>();
            return Ok(Data);
        }
    }
}
