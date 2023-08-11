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
        public readonly IRelatedWebsiteService _RelatedWebsiteService;
        public RelatedWebsiteController(IRelatedWebsiteService relatedWebsiteService)
        {
            _RelatedWebsiteService = relatedWebsiteService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<RelatedWebsiteDto>> Get(string Id)
        {
            var Data = await _RelatedWebsiteService.GetById(Id);
            if (Data is null)
                return NotFound();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RelatedWebsiteDto>>> GetAll(int Page = 1)
        {
            var Data = await _RelatedWebsiteService.GetAll(page:Page,size:6);
            return Ok(Data);
        }
    }
}
