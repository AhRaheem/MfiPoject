

using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AboutUsController : Controller
	{
		public readonly IAboutUsService _AboutUsService;
        private IValidator<AboutUsUpdateDto> _UpdateValidator;
        public AboutUsController(IAboutUsService AboutUsService, IValidator<AboutUsUpdateDto> UpdateValidator)
		{
			_AboutUsService = AboutUsService;
            _UpdateValidator = UpdateValidator;
        }

		// GET: AboutUsController/Edit/5
		public async Task<ActionResult> Edit()
		{
            var Entity = await _AboutUsService.GetUpdateInfo();
			return View(Entity);
		}

		// POST: AboutUsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(AboutUsUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _AboutUsService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}
	}
}
