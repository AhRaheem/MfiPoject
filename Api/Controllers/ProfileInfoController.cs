using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.ProfileInfo;
using Infrastructure.Dtos.Service;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileInfoController : ControllerBase
    {
        public readonly IProfileInfoService _ProfileInfoUsService;
        public ProfileInfoController(IProfileInfoService profileInfoUsService)
        {
            _ProfileInfoUsService = profileInfoUsService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<ProfileInfoDto>>> Get(int Page)
        {
            var Data = await _ProfileInfoUsService.GetAll("");
            return Ok(Data);
        }
    }
}
