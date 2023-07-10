

using Infrastructure.Dtos.RelatedWebsite;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class RelatedWebsiteController : Controller
	{
		public readonly IRelatedWebsiteService _relatedWebsiteService;
        private IValidator<RelatedWebsiteCreateDto> _CreateValidator;
        private IValidator<RelatedWebsiteUpdateDto> _UpdateValidator;

        public RelatedWebsiteController(IRelatedWebsiteService relatedWebsiteService, IValidator<RelatedWebsiteCreateDto> CreateValidator, IValidator<RelatedWebsiteUpdateDto> UpdateValidator)
		{
			_relatedWebsiteService = relatedWebsiteService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: RelatedWebsiteController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _relatedWebsiteService.GetAll(q,page,size));
		}

		// GET: RelatedWebsiteController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: RelatedWebsiteController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(RelatedWebsiteCreateDto Model)
		{
			if (ValidRslt.IsValid)
			{
				var Rslt = await _relatedWebsiteService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// GET: RelatedWebsiteController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
			var Entity = await _relatedWebsiteService.GetById(id);
			return View(Entity);
		}

		// POST: RelatedWebsiteController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(RelatedWebsiteUpdateDto Model)
		{
			if (ValidRslt.IsValid)
			{
				var Rslt = await _relatedWebsiteService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// POST: RelatedWebsiteController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _relatedWebsiteService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
