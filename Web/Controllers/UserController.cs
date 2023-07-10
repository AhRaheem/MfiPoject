

using Infrastructure.Dtos.User;


namespace Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class UserController : Controller
	{
		public readonly IUserService _userService;
        private IValidator<UserCreateDto> _CreateValidator;

        public UserController(IUserService userService, IValidator<UserCreateDto> CreateValidator)
		{
			_userService = userService;
            _CreateValidator = CreateValidator;
        }

		// GET: UserController
		public async Task<ActionResult> Index(string? q,int page=1, int size=10)
		{
			return View(await _userService.GetAll(q,page,size));
		}

		// GET: UserController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(UserCreateDto Model)
		{
			var ValidRslt = await _CreateValidator.ValidateAsync(Model);
            ValidRslt.AddToModelState(this.ModelState);
            if (ValidRslt.IsValid) 
			{
				var Rslt = await _userService.Create(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// GET: UserController/Edit/5
		public async Task<ActionResult> Edit(string id)
		{
			var Entity = await _userService.GetById(id);
			return View(Entity);
		}

		// POST: UserController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(UserUpdateDto Model)
		{
			if (ValidRslt.IsValid)
			{
				var Rslt = await _userService.Update(Model);
				if (Rslt)
					return RedirectToAction(nameof(Index));
			}
			return View(Model);
		}

		// POST: UserController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(string id)
		{
			var Rslt = await _userService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
