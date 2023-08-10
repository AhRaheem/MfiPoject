

using FluentValidation;
using Infrastructure.Dtos.News;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class NewsController : Controller
	{
		public readonly INewsService _NewsService;
		
        private IValidator<NewsCreateDto> _CreateValidator;
        private IValidator<NewsUpdateDto> _UpdateValidator;
        public NewsController(INewsService NewsService, IValidator<NewsCreateDto> CreateValidator, IValidator<NewsUpdateDto> UpdateValidator)
		{
			_NewsService = NewsService;
			
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: NewsController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _NewsService.GetAll(q,page,size));
		}

		// GET: NewsController/Create
		public async Task<ActionResult> Create()
		{
            
			return View();
		}

		// POST: NewsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(NewsCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _NewsService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: NewsController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            
            var Entity = await _NewsService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: NewsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(NewsUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _NewsService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: NewsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _NewsService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
