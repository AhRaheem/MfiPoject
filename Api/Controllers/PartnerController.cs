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
        public readonly IPartnerService _PartnerService;
        public PartnerController(IPartnerService partnerService)
        {
            _PartnerService = partnerService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<PartnerDto>> Get(string Id)
        {
            var Data = await _PartnerService.GetById(Id);
            if(Data is null)
                return NotFound();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PartnerDto>>> GetAll(int Page=1)
        {
            var Data = await _PartnerService.GetAll(page: Page, size: 6);
            return Ok(Data);
        }
    }
}
