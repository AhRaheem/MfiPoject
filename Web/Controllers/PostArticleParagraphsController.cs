

using FluentValidation;
using Infrastructure.Dtos.PostArticleParagraphs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PostArticleParagraphsController : Controller
	{
		public readonly IPostArticleParagraphsService _PostArticleParagraphsService;
		public readonly IPostArticleParagraphsCategoryService _PostArticleParagraphsCategoryService;
        private IValidator<PostArticleParagraphsCreateDto> _CreateValidator;
        private IValidator<PostArticleParagraphsUpdateDto> _UpdateValidator;
        public PostArticleParagraphsController(IPostArticleParagraphsService PostArticleParagraphsService, IPostArticleParagraphsCategoryService PostArticleParagraphsCategoryService, IValidator<PostArticleParagraphsCreateDto> CreateValidator, IValidator<PostArticleParagraphsUpdateDto> UpdateValidator)
		{
			_PostArticleParagraphsService = PostArticleParagraphsService;
			_PostArticleParagraphsCategoryService = PostArticleParagraphsCategoryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: PostArticleParagraphsController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _PostArticleParagraphsService.GetAll(q,page,size));
		}

		// GET: PostArticleParagraphsController/Create
		public async Task<ActionResult> Create()
		{
            ViewData["PostArticleParagraphsCategoryId"] = new SelectList(await _PostArticleParagraphsCategoryService.GetList(), "Id","NameAr");
			return View();
		}

		// POST: PostArticleParagraphsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PostArticleParagraphsCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _PostArticleParagraphsService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["PostArticleParagraphsCategoryId"] = new SelectList(await _PostArticleParagraphsCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: PostArticleParagraphsController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            ViewData["PostArticleParagraphsCategoryId"] = new SelectList(await _PostArticleParagraphsCategoryService.GetList(), "Id", "NameAr");
            var Entity = await _PostArticleParagraphsService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: PostArticleParagraphsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(PostArticleParagraphsUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _PostArticleParagraphsService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            ViewData["PostArticleParagraphsCategoryId"] = new SelectList(await _PostArticleParagraphsCategoryService.GetList(), "Id", "NameAr");
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: PostArticleParagraphsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _PostArticleParagraphsService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
