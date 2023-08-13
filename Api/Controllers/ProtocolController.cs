using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Protocol;
using Infrastructure.Dtos.ProfileInfo;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtocolController : ControllerBase
    {
        public readonly IProtocolService _ProtocolService;
        public ProtocolController(IProtocolService partnerService)
        {
            _ProtocolService = partnerService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<ProtocolDto>> Get(string Id)
        {
            var Data = await _ProtocolService.GetById(Id);
            if(Data is null)
                return NotFound();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProtocolDto>>> GetAll(int Page=1)
        {
            var Data = await _ProtocolService.GetAll(page: Page, size: 6);
            return Ok(Data);
        }
    }
}
