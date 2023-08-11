using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Service;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public readonly IServiceService _ServiceService;

        public ServiceController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<ServiceDto>> Get(string Id)
        {
            var Data = await _ServiceService.GetById(Id);
            if(Data is null)
                return NotFound();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ServiceDto>>> GetAll(int Page=1)
        {
            var Data = await _ServiceService.GetAll(page:Page,size:6);
            return Ok(Data);
        }
    }
}
