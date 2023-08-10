

using Core.Entites;
using FluentValidation;
using Infrastructure.Dtos.PostArticleParagraph;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PostArticleParagraphsController : Controller
	{
		public readonly IPostArticleParagraphService _PostArticleParagraphsService;
        private IValidator<PostArticleParagraphCreateDto> _CreateValidator;
        private IValidator<PostArticleParagraphUpdateDto> _UpdateValidator;
        public PostArticleParagraphsController(IPostArticleParagraphService PostArticleParagraphsService, IValidator<PostArticleParagraphCreateDto> CreateValidator, IValidator<PostArticleParagraphUpdateDto> UpdateValidator)
		{
			_PostArticleParagraphsService = PostArticleParagraphsService;
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
			return View();
		}

		// POST: PostArticleParagraphsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PostArticleParagraphCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _PostArticleParagraphsService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: PostArticleParagraphsController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            var Entity = await _PostArticleParagraphsService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: PostArticleParagraphsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(PostArticleParagraphUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _PostArticleParagraphsService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
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
