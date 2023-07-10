

using Core.Enums;
using FluentValidation;
using Infrastructure.Dtos.Post;

namespace Web.Controllers
{
	[Authorize]
	public class PostController : Controller
	{
		public readonly IPostService _postService;
        private IValidator<PostCreateDto> _CreateValidator;
        private IValidator<PostUpdateDto> _UpdateValidator;
        private IValidator<PostParagraphCreateDto> _ParagraphCreateDtoValidator;
        private IValidator<PostParagraphUpdateDto> _ParagraphUpdateDtoValidator;
        private IValidator<PostAffiliateLawCreateDto> _AffiliateLawCreateDtoValidator;
        private IValidator<PostAffiliateLawUpdateDto> _AffiliateLawUpdateDtoValidator;
        public PostController(IPostService postService, 
            IValidator<PostCreateDto> CreateValidator, 
            IValidator<PostUpdateDto> UpdateValidator, 
            IValidator<PostParagraphCreateDto> ParagraphCreateDtoValidator,
            IValidator<PostParagraphUpdateDto> ParagraphUpdateDtoValidator,
            IValidator<PostAffiliateLawCreateDto> AffiliateLawCreateDtoValidator,
            IValidator<PostAffiliateLawUpdateDto> AffiliateLawUpdateDtoValidator
            )
		{
			_postService = postService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
            _ParagraphCreateDtoValidator = ParagraphCreateDtoValidator;
            _ParagraphUpdateDtoValidator = ParagraphUpdateDtoValidator;
        }

		// GET: PostController
		public async Task<ActionResult> Index(PostType PostType, string? q,int page=1, int size=10)
		{
			return View(await _postService.GetAll(PostType,q,page,size));
		}

		// GET: PostController/Create
		public ActionResult Create(PostType PostType)
		{
            return View();
		}

		// POST: PostController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PostCreateDto Model)
		{
            Model.Id = Guid.NewGuid().ToString();
            var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _postService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Edit), new { Id = Model.Id });
			}
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// GET: PostController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
			var Entity = await _postService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: PostController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(PostUpdateDto Model)
		{
            var ValidRslt = await _UpdateValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
			{
				var Rslt = await _postService.Update(Model);
                if (Rslt)
                    return RedirectToAction(nameof(Index), new { PostType = Model.PostType });
			}
			if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
		}

		// POST: PostController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _postService.Delete(id);
			return RedirectToAction(nameof(Index));
		}

        // GET: PostParagraphController/Create
        public async Task<ActionResult> CreateParagraph(string PostId)
        {
            var Post = await _postService.GetByIdWithParagraphs(PostId);
            if (Post is null)
                return RedirectToAction(nameof(Index));
            ViewData["PostInfo"] = Post;
            return View();
        }

        // POST: PostParagraphController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateParagraph(PostParagraphCreateDto Model)
        {
            var ValidRslt = await _ParagraphCreateDtoValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
            {
                var Rslt = await _postService.CreatePostParagraph(Model);
                if (Rslt)
                    return RedirectToAction(nameof(CreateParagraph), new { PostId = Model.PostId });
            }
            var Post = await _postService.GetByIdWithParagraphs(Model.PostId);
            ViewData["PostInfo"] = Post;
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
        }

        // GET: PostParagraphController/Update
        public async Task<ActionResult> UpdateParagraph(string PostId)
        {
            var Post = await _postService.GetByIdWithParagraphs(PostId);
            if (Post is null)
                return RedirectToAction(nameof(Index));
            ViewData["PostInfo"] = Post;
            return View();
        }

        // POST: PostParagraphController/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateParagraph(PostParagraphUpdateDto Model)
        {
            var ValidRslt = await _ParagraphUpdateDtoValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
            {
                var Rslt = await _postService.UpdatePostParagraph(Model);
                if (Rslt)
                    return RedirectToAction(nameof(UpdateParagraph), new { PostId = Model.PostId });
            }
            var Post = await _postService.GetByIdWithParagraphs(Model.PostId);
            ViewData["PostInfo"] = Post;
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePostParagraph(string id, string PostId)
        {
            var Rslt = await _postService.DeletePostParagraph(id);
            return RedirectToAction(nameof(CreateParagraph), new { PostId = PostId });
        }

        // GET: PostAffiliateLawController/Create
        public async Task<ActionResult> CreateAffiliateLaw(string PostId)
        {
            var Post = await _postService.GetByIdWithAffiliateLaws(PostId);
            if (Post is null)
                return RedirectToAction(nameof(Index));
            ViewData["PostInfo"] = Post;
            return View();
        }

        // POST: PostAffiliateLawController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAffiliateLaw(PostAffiliateLawCreateDto Model)
        {
            var ValidRslt = await _AffiliateLawCreateDtoValidator.ValidateAsync(Model);
            if (ValidRslt.IsValid)
            {
                var Rslt = await _postService.CreatePostAffiliateLaw(Model);
                if (Rslt)
                    return RedirectToAction(nameof(CreateAffiliateLaw), new { PostId = Model.PostId });
            }
            var Post = await _postService.GetByIdWithAffiliateLaws(Model.PostId);
            ViewData["PostInfo"] = Post;
            if(!ValidRslt.IsValid)
                ValidRslt.AddToModelState(this.ModelState);
            return View(Model);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePostAffiliateLaw(string id, string PostId)
        {
            var Rslt = await _postService.DeletePostAffiliateLaw(id);
            return RedirectToAction(nameof(CreateAffiliateLaw), new { PostId = PostId });
        }


        public async Task<ActionResult> Details(string Id) 
        {
            return View(await _postService.GetDetails(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Publish(string Id) 
        {
            await _postService.Publish(Id);
            return RedirectToAction(nameof(Edit), new { Id = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reject(PostRejectDto postRejectDto)
        {
            await _postService.Reject(postRejectDto);
            return RedirectToAction(nameof(Edit), new { Id = postRejectDto.Id });
        }
    }
}
