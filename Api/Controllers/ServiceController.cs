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

        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {
            var Data = new ServiceDto();
            return Ok(Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Data = new List<ServiceDto>();
            return Ok(Data);
        }
    }
}
