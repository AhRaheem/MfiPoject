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
        public ProfileInfoController()
        {
        }

        [HttpGet("Get")]
        public async Task<ActionResult<ProfileInfoDto>> Get(string Id)
        {
            var Data = new ProfileInfoDto();
            return Ok(Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProfileInfoDto>>> GetAll(int Page)
        {
            var Data = new List<ProfileInfoDto>();
            return Ok(Data);
        }
    }
}
