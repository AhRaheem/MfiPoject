

using FluentValidation;
using Infrastructure.Dtos.PostServiceParagraphImage;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PostServiceParagraphImageController : Controller
	{
		public readonly IPostServiceParagraphImageService _PostServiceParagraphImageService;
        private IValidator<PostServiceParagraphImageCreateDto> _CreateValidator;
        private IValidator<PostServiceParagraphImageUpdateDto> _UpdateValidator;
        public PostServiceParagraphImageController(IPostServiceParagraphImageService PostServiceParagraphImageService, IValidator<PostServiceParagraphImageCreateDto> CreateValidator, IValidator<PostServiceParagraphImageUpdateDto> UpdateValidator)
		{
			_PostServiceParagraphImageService = PostServiceParagraphImageService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: PostServiceParagraphImageController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _PostServiceParagraphImageService.GetAll(q,page,size));
		}

		// GET: PostServiceParagraphImageController/Create
		public async Task<ActionResult> Create()
		{
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
				var Rslt = await _PostServiceParagraphImageService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: PostServiceParagraphImageController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
            var Entity = await _PostServiceParagraphImageService.GetUpdateInfo(id);
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
				var Rslt = await _PostServiceParagraphImageService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: PostServiceParagraphImageController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _PostServiceParagraphImageService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
