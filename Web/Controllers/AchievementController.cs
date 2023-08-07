

using FluentValidation;
using Infrastructure.Dtos.Achievement;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AchievementController : Controller
	{
		public readonly IAchievementService _partnerService;
		public readonly IAchievementCategoryService _partnerCategoryService;
        private IValidator<AchievementCreateDto> _CreateValidator;
        private IValidator<AchievementUpdateDto> _UpdateValidator;
        public AchievementController(IAchievementService partnerService, IAchievementCategoryService partnerCategoryService, IValidator<AchievementCreateDto> CreateValidator, IValidator<AchievementUpdateDto> UpdateValidator)
		{
			_partnerService = partnerService;
			_partnerCategoryService = partnerCategoryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: AchievementController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _partnerService.GetAll(q,page,size));
		}

		// GET: AchievementController/Create
		public async Task<ActionResult> Create()
		{
            ViewData["AchievementCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id","NameAr");
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
				var Rslt = await _partnerService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["AchievementCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: AchievementController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            ViewData["AchievementCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            var Entity = await _partnerService.GetUpdateInfo(id);
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
				var Rslt = await _partnerService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["AchievementCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: AchievementController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _partnerService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
