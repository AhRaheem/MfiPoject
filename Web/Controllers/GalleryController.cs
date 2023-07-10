

using Core.Entites;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Dtos.Gallery;
using Infrastructure.Models;
using System;

namespace Web.Controllers
{
	[Authorize]
	public class GalleryController : Controller
	{
		public readonly IGalleryService _galleryService;
        private IValidator<GalleryCreateDto> _CreateValidator;
        private IValidator<GalleryUpdateDto> _UpdateValidator;

        public GalleryController(IGalleryService galleryService, IValidator<GalleryCreateDto> CreateValidator , IValidator<GalleryUpdateDto> UpdateValidator)
		{
			_galleryService = galleryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: GalleryController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _galleryService.GetAll(q,page,size));
		}

		// GET: GalleryController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: GalleryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(GalleryCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _galleryService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// GET: GalleryController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
			var Entity = await _galleryService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: GalleryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(GalleryUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _galleryService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// POST: GalleryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _galleryService.Delete(id);
			return RedirectToAction(nameof(Index));
		}

        // GET: GalleryItemController/Create
        public async Task<ActionResult> CreateItem(string GalleryId)
        {
			var Gallery = await _galleryService.GetByIdWithItems(GalleryId);
			if (Gallery is null)
				return RedirectToAction(nameof(Index));
			ViewData["GalleryInfo"] = Gallery;
            return View();
        }

        // POST: GalleryItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateItem(GalleryItemCreateDto Model)
        {
            if (ValidRslt.IsValid)
            {
                var Rslt = await _galleryService.CreateGalleryItem(Model);
				if (Rslt)
                    return RedirectToAction(nameof(CreateItem), new { GalleryId = Model.GalleryId });
            }
            var Gallery = await _galleryService.GetByIdWithItems(Model.GalleryId);
            ViewData["GalleryInfo"] = Gallery;
            return View(Model);
        }

        // POST: GalleryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteGallleryItem(string id,string GalleryId)
        {
            var Rslt = await _galleryService.DeleteGalleryItem(id);
            return RedirectToAction(nameof(CreateItem), new { GalleryId = GalleryId });
        }
    }
}
