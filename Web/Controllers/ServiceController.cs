

using FluentValidation;
using Infrastructure.Dtos.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ServiceController : Controller
	{
		public readonly IServiceService _ServiceService;
        private IValidator<ServiceCreateDto> _CreateValidator;
        private IValidator<ServiceUpdateDto> _UpdateValidator;
        public ServiceController(IServiceService ServiceService, IValidator<ServiceCreateDto> CreateValidator, IValidator<ServiceUpdateDto> UpdateValidator)
		{
			_ServiceService = ServiceService;
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
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: ServiceController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
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
