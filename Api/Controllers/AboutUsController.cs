using Api.Helpers;
using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        public readonly IAboutUsService _AboutUsService;
        public readonly IDirectorsCategoryService _DirectorsCategoryService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            _AboutUsService = aboutUsService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<AboutUsPageDto>> Get()
        {
            var Data = new AboutUsPageDto();
            Data.AboutUsDto = await _AboutUsService.GetUpdateInfo();
            Data.DirectorsCategoryLstDto = (await _DirectorsCategoryService.GetAllWithSubData()).Items;
            return Ok(Data);
        }

        [HttpGet("GetHomeIntoWord")]
        public async Task<ActionResult<string>> GetHomeIntoWord() 
        {
            var Lang = Request.GetLanguage();
            var Word = "";
            var AboutUsInfo = (await _AboutUsService.GetUpdateInfo());
            if (AboutUsInfo is not null)
                Word = Lang == "ar" ? AboutUsInfo.IntroAr : AboutUsInfo.IntroEn;
            return Ok(Word);
        }
    }
}
