

using FluentValidation;
using Infrastructure.Dtos.Partner;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PartnerController : Controller
	{
		public readonly IPartnerService _partnerService;
		public readonly IPartnerCategoryService _partnerCategoryService;
        private IValidator<PartnerCreateDto> _CreateValidator;
        private IValidator<PartnerUpdateDto> _UpdateValidator;
        public PartnerController(IPartnerService partnerService, IPartnerCategoryService partnerCategoryService, IValidator<PartnerCreateDto> CreateValidator, IValidator<PartnerUpdateDto> UpdateValidator)
		{
			_partnerService = partnerService;
			_partnerCategoryService = partnerCategoryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: PartnerController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _partnerService.GetAll(q,page,size));
		}

		// GET: PartnerController/Create
		public async Task<ActionResult> Create()
		{
            ViewData["PartnerCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id","NameAr");
			return View();
		}

		// POST: PartnerController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PartnerCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _partnerService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["PartnerCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: PartnerController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            ViewData["PartnerCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            var Entity = await _partnerService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: PartnerController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(PartnerUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _partnerService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["PartnerCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: PartnerController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _partnerService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
