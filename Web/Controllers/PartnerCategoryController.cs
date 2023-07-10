


using Infrastructure.Dtos.PartnerCategory;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PartnerCategoryController : Controller
	{
		public readonly IPartnerCategoryService _partnerService;
        private IValidator<PartnerCategoryCreateDto> _CreateValidator;
        private IValidator<PartnerCategoryUpdateDto> _UpdateValidator;

        public PartnerCategoryController(IPartnerCategoryService partnerCategoryService, IValidator<PartnerCategoryCreateDto> CreateValidator, IValidator<PartnerCategoryUpdateDto> UpdateValidator)
        {
            _partnerService = partnerCategoryService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

        // GET: PartnerCategoryController
        public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _partnerService.GetAll(q,page,size));
		}

		// GET: PartnerCategoryController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PartnerCategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PartnerCategoryCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _partnerService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// GET: PartnerCategoryController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
			var Entity = await _partnerService.GetById(id);
			return View(Entity);
		}

		// POST: PartnerCategoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(PartnerCategoryUpdateDto Model)
		{
			if (ValidRslt.IsValid)
			{
				var Rslt = await _partnerService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// POST: PartnerCategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _partnerService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
