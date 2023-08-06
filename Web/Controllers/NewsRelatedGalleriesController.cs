﻿

using FluentValidation;
using Infrastructure.Dtos.NewsRelatedGalleries;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class NewsRelatedGalleriesController : Controller
	{
		public readonly INewsRelatedGalleriesService _NewsRelatedGalleriesService;
		public readonly INewsRelatedGalleriesCategoryService _NewsRelatedGalleriesCategoryService;
        private IValidator<NewsRelatedGalleriesCreateDto> _CreateValidator;
        private IValidator<NewsRelatedGalleriesUpdateDto> _UpdateValidator;
        public NewsRelatedGalleriesController(INewsRelatedGalleriesService NewsRelatedGalleriesService, INewsRelatedGalleriesCategoryService NewsRelatedGalleriesCategoryService, IValidator<NewsRelatedGalleriesCreateDto> CreateValidator, IValidator<NewsRelatedGalleriesUpdateDto> UpdateValidator)
		{
			_NewsRelatedGalleriesService = NewsRelatedGalleriesService;
			_NewsRelatedGalleriesCategoryService = NewsRelatedGalleriesCategoryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: NewsRelatedGalleriesController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _NewsRelatedGalleriesService.GetAll(q,page,size));
		}

		// GET: NewsRelatedGalleriesController/Create
		public async Task<ActionResult> Create()
		{
            ViewData["NewsRelatedGalleriesCategoryId"] = new SelectList(await _NewsRelatedGalleriesCategoryService.GetList(), "Id","NameAr");
			return View();
		}

		// POST: NewsRelatedGalleriesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(NewsRelatedGalleriesCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _NewsRelatedGalleriesService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["NewsRelatedGalleriesCategoryId"] = new SelectList(await _NewsRelatedGalleriesCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: NewsRelatedGalleriesController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            ViewData["NewsRelatedGalleriesCategoryId"] = new SelectList(await _NewsRelatedGalleriesCategoryService.GetList(), "Id", "NameAr");
            var Entity = await _NewsRelatedGalleriesService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: NewsRelatedGalleriesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(NewsRelatedGalleriesUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _NewsRelatedGalleriesService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["NewsRelatedGalleriesCategoryId"] = new SelectList(await _NewsRelatedGalleriesCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: NewsRelatedGalleriesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _NewsRelatedGalleriesService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}