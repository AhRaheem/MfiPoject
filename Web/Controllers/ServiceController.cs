

using FluentValidation;
using Infrastructure.Dtos.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ServiceController : Controller
	{
		public readonly IServiceService _ServiceService;
		public readonly IServiceCategoryService _ServiceCategoryService;
        private IValidator<ServiceCreateDto> _CreateValidator;
        private IValidator<ServiceUpdateDto> _UpdateValidator;
        public ServiceController(IServiceService ServiceService, IServiceCategoryService ServiceCategoryService, IValidator<ServiceCreateDto> CreateValidator, IValidator<ServiceUpdateDto> UpdateValidator)
		{
			_ServiceService = ServiceService;
			_ServiceCategoryService = ServiceCategoryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: ServiceController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _ServiceService.GetAll(q,page,size));
		}

		// GET: ServiceController/Create
		public async Task<ActionResult> Create()
		{
            ViewData["ServiceCategoryId"] = new SelectList(await _ServiceCategoryService.GetList(), "Id","NameAr");
			return View();
		}

		// POST: ServiceController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ServiceCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _ServiceService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["ServiceCategoryId"] = new SelectList(await _ServiceCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: ServiceController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            ViewData["ServiceCategoryId"] = new SelectList(await _ServiceCategoryService.GetList(), "Id", "NameAr");
            var Entity = await _ServiceService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: ServiceController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(ServiceUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _ServiceService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["ServiceCategoryId"] = new SelectList(await _ServiceCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: ServiceController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _ServiceService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
