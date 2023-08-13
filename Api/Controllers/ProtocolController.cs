using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Protocol;
using Infrastructure.Dtos.ProfileInfo;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Enums;

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
        public async Task<ActionResult<List<ProtocolDto>>> GetAll(DateTime? FromDate, DateTime? ToDate, string q = "", SortByType SortByTypeFlag = 0, int Page = 1, int Size = 9)
        {
            var Data = await _ProtocolService.GetAll(FromDate, ToDate, q, Page, Size);
            return Ok(Data);
        }
    }
}
