

using FluentValidation;
using Infrastructure.Dtos.PostServiceParagraph;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PostServiceParagraphController : Controller
	{
		public readonly IPostServiceParagraphService _partnerService;
		public readonly IPostServiceParagraphCategoryService _partnerCategoryService;
        private IValidator<PostServiceParagraphCreateDto> _CreateValidator;
        private IValidator<PostServiceParagraphUpdateDto> _UpdateValidator;
        public PostServiceParagraphController(IPostServiceParagraphService partnerService, IPostServiceParagraphCategoryService partnerCategoryService, IValidator<PostServiceParagraphCreateDto> CreateValidator, IValidator<PostServiceParagraphUpdateDto> UpdateValidator)
		{
			_partnerService = partnerService;
			_partnerCategoryService = partnerCategoryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: PostServiceParagraphController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _partnerService.GetAll(q,page,size));
		}

		// GET: PostServiceParagraphController/Create
		public async Task<ActionResult> Create()
		{
            ViewData["PostServiceParagraphCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id","NameAr");
			return View();
		}

		// POST: PostServiceParagraphController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PostServiceParagraphCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _partnerService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["PostServiceParagraphCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: PostServiceParagraphController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            ViewData["PostServiceParagraphCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            var Entity = await _partnerService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: PostServiceParagraphController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(PostServiceParagraphUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _partnerService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["PostServiceParagraphCategoryId"] = new SelectList(await _partnerCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: PostServiceParagraphController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _partnerService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
