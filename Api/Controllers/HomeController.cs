using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IAboutUsService _AboutUsService;
        private IValidator<AboutUsUpdateDto> _UpdateValidator;
        public HomeController(IAboutUsService AboutUsService, IValidator<AboutUsUpdateDto> UpdateValidator)
        {
            _AboutUsService = AboutUsService;
            _UpdateValidator = UpdateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var Info = await _AboutUsService.GetUpdateInfo();
            AboutUsMainPage InfoDto = new AboutUsMainPage();
            return Ok(InfoDto);
        }
    }
}
