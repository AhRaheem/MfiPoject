

using FluentValidation;
using Infrastructure.Dtos.NewsRelatedNews;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class NewsRelatedNewsController : Controller
	{
		public readonly INewsRelatedNewsService _NewsRelatedNewsService;
        private IValidator<NewsRelatedNewsCreateDto> _CreateValidator;
        private IValidator<NewsRelatedNewsUpdateDto> _UpdateValidator;
        public NewsRelatedNewsController(INewsRelatedNewsService NewsRelatedNewsService, IValidator<NewsRelatedNewsCreateDto> CreateValidator, IValidator<NewsRelatedNewsUpdateDto> UpdateValidator)
		{
			_NewsRelatedNewsService = NewsRelatedNewsService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: NewsRelatedNewsController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _NewsRelatedNewsService.GetAll(q,page,size));
		}

		// GET: NewsRelatedNewsController/Create
		public async Task<ActionResult> Create()
		{
			return View();
		}

		// POST: NewsRelatedNewsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(NewsRelatedNewsCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _NewsRelatedNewsService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: NewsRelatedNewsController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            var Entity = await _NewsRelatedNewsService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: NewsRelatedNewsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(NewsRelatedNewsUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _NewsRelatedNewsService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: NewsRelatedNewsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _NewsRelatedNewsService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
