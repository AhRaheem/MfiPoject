

using Infrastructure.Dtos.ProfileInfo;

namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ProfileInfoController : Controller
	{
		public readonly IProfileInfoService _profileInfoService;
        private IValidator<ProfileInfoCreateDto> _CreateValidator;
        private IValidator<ProfileInfoUpdateDto> _UpdateValidator;

        public ProfileInfoController(IProfileInfoService profileInfoService, IValidator<ProfileInfoCreateDto> CreateValidator, IValidator<ProfileInfoUpdateDto> UpdateValidator)
		{
			_profileInfoService = profileInfoService;
            _CreateValidator = CreateValidator;
            _UpdateValidator = UpdateValidator;
        }

		// GET: ProfileInfoController
		public async Task<ActionResult> Index(string? q="")
		{
			return View(await _profileInfoService.GetAll(q));
		}

		// GET: ProfileInfoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ProfileInfoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ProfileInfoCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _profileInfoService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// GET: ProfileInfoController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
			var Entity = await _profileInfoService.GetUpdateInfo(id);
			return View(Entity);
		}

		// POST: ProfileInfoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(ProfileInfoUpdateDto Model)
		{
			if (ValidRslt.IsValid)
			{
				var Rslt = await _profileInfoService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// POST: ProfileInfoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _profileInfoService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
