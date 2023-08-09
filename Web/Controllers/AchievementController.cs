

using FluentValidation;
using Infrastructure.Dtos.Achievement;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AchievementController : Controller
	{
		public readonly IAchievementService _AchievementService;
        private IValidator<AchievementCreateDto> _CreateValidator;
        private IValidator<AchievementUpdateDto> _UpdateValidator;
        public AchievementController(IAchievementService AchievementService, IValidator<AchievementCreateDto> CreateValidator, IValidator<AchievementUpdateDto> UpdateValidator)
		{
			_AchievementService = AchievementService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: AchievementController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _AchievementService.GetAll(q,page,size));
		}

		// GET: AchievementController/Create
		public async Task<ActionResult> Create()
		{
			return View();
		}

		// POST: AchievementController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(AchievementCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _AchievementService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: AchievementController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            var Entity = await _AchievementService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: AchievementController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(AchievementUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _AchievementService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: AchievementController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _AchievementService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
