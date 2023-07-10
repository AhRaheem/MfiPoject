
using Infrastructure.Dtos.Post;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public readonly IUserService _userService;
        private IValidator<LoginViewModel> _LoginValidator;
        public AccountController(IUserService userService, IValidator<LoginViewModel> LoginValidator)
        {
            _userService = userService;
            _LoginValidator = LoginValidator;
        }
    
        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("index","home");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "/")
        {
            ViewData["ReturnUrl"] = returnUrl;
            var ValidRslt = await _LoginValidator.ValidateAsync(model);
            if (ValidRslt.IsValid)
            {

                var result = await _userService.PasswordSignInAsync(model);
                if (result)
                    return RedirectToLocal(returnUrl);
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(model);
        }

        //// GET: /Manage/ChangePassword
        //[HttpGet, Authorize(Roles = "Admin")]
        //public IActionResult ForceChangePassword(string UserId)
        //{
        //    ViewData["UserId"] = UserId;
        //    return View();
        //}

        ////
        //// POST: /Manage/ChangePassword
        //[HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "Admin")]
        //public async Task<IActionResult> ForceChangePassword(ChangePasswordModel model)
        //{
        //    var user = await _userService.GetById(model.UserId);

        //    if (user != null)
        //    {
        //        var Rslt = await _userService.ForceChangeUserPassword(model.UserId, model.NewPassword);
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();
            return RedirectToAction("index", "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }
    }
}
