using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.Achievement;
using Infrastructure.Dtos.Service;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        public AchievementController()
        {
        }

        [HttpGet("Get")]
        public async Task<ActionResult<AchievementDto>> Get(string Id)
        {
            var Data = new AchievementDto();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AchievementDto>>> GetAll()
        {
            var Data = new List<AchievementDto>();
            return Ok(Data);
        }
    }
}
