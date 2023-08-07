

using FluentValidation;
using Infrastructure.Dtos.PostServiceParagraphImage;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PostServiceParagraphImageController : Controller
	{
		public readonly IPostServiceParagraphImageService _partnerService;
		public readonly IPostServiceParagraphImageCategoryService _partnerCategoryService;
        private IValidator<PostServiceParagraphImageCreateDto> _CreateValidator;
        private IValidator<PostServiceParagraphImageUpdateDto> _UpdateValidator;
        public PostServiceParagraphImageController(IPostServiceParagraphImageService partnerService, IPostServiceParagraphImageCategoryService partnerCategoryService, IValidator<PostServiceParagraphImageCreateDto> CreateValidator, IValidator<PostServiceParagraphImageUpdateDto> UpdateValidator)
		{
			_partnerService = partnerService;
			_partnerCategoryService = partnerCategoryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: PostServiceParagraphImageController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _partnerService.GetAll(q,page,size));
		}

		// GET: PostServiceParagraphImageController/Create
		public async Task<ActionResult> Create()
		{
            ViewData["PostServiceParagraphImageCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id","NameAr");
			return View();
		}

		// POST: PostServiceParagraphImageController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PostServiceParagraphImageCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _partnerService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["PostServiceParagraphImageCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: PostServiceParagraphImageController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            ViewData["PostServiceParagraphImageCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            var Entity = await _partnerService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: PostServiceParagraphImageController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(PostServiceParagraphImageUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _partnerService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["PostServiceParagraphImageCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: PostServiceParagraphImageController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _partnerService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
