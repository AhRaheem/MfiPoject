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

        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {
            var Data = new AchievementDto();
            return Ok(Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Data = new List<AchievementDto>();
            return Ok(Data);
        }
    }
}
