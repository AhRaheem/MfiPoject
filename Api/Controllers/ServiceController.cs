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
        public ServiceController()
        {
        }

        [HttpGet("Get")]
        public async Task<ActionResult<ServiceDto>> Get(string Id)
        {
            var Data = new ServiceDto();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ServiceDto>>> GetAll(int Page)
        {
            var Data = new List<ServiceDto>();
            return Ok(Data);
        }
    }
}
