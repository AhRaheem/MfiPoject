using Api.Models;
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
        public async Task<ActionResult<List<ProfileInfoModel>>> Get(int Page)
        {
            var Entities = await _ProfileInfoUsService.GetAll("");
            var Data = new ProfileInfoModel();
            Data.ContactUs = Entities.Where(x => x.Category == Core.Enums.ProfileInfoCategory.Address || x.Category == Core.Enums.ProfileInfoCategory.Phone || x.Category == Core.Enums.ProfileInfoCategory.Email || x.Category == Core.Enums.ProfileInfoCategory.Fax || x.Category == Core.Enums.ProfileInfoCategory.MapLocation).ToList();
            Data.SocialMedia = Entities.Where(x => x.Category == Core.Enums.ProfileInfoCategory.SocialMedia).ToList();
            Data.BankAccountNumbers = Entities.Where(x => x.Category == Core.Enums.ProfileInfoCategory.BankAccountNumber).ToList();
            Data.HotLines = Entities.Where(x => x.Category == Core.Enums.ProfileInfoCategory.HotLines).ToList();
                
            return Ok(Data);
        }
    }
}
