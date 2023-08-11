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
        public readonly IAchievementService _AchievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _AchievementService = achievementService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<AchievementDto>> Get(string Id)
        {
            var Data = await _AchievementService.GetById(Id);
            if (Data is null)
                return NotFound();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AchievementDto>>> GetAll(int Page = 1)
        {
            var Data = await _AchievementService.GetAll(page: Page, size:6);
            return Ok(Data);
        }
    }
}
