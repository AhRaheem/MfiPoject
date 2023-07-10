

using Microsoft.AspNetCore.Hosting;

namespace Web.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IWebHostEnvironment HostingEnvironment;
        public LanguageController(IWebHostEnvironment environment)
        {
            HostingEnvironment= environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string MissedWords()
        {
            string wordLst = "";
            foreach (var item in Infrastructure.Helpers.Translator.MissedTranslateWords)
            {
                wordLst += $"{item}:";
            }
            return wordLst;
        }

        public ActionResult ReloadLanguageFiles()
        {
            Infrastructure.Helpers.Translator.MissedTranslateWords.Clear();
            Infrastructure.Helpers.Translator.LoadLanguageFiles(HostingEnvironment.WebRootPath);
            return RedirectToAction(nameof(Index));
        }

		public IActionResult ChangeLang(string id, string ReturnUrl = "/")
		{
			var options = new CookieOptions
			{
				HttpOnly = true,
				IsEssential = true,
				Secure = false,
				SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
				Expires = DateTime.UtcNow.AddYears(10)
			};

			Response.Cookies.Append("Lang", id, options);

			if (Url.IsLocalUrl(ReturnUrl))
			{
				return Redirect(ReturnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}


		}


		public void RemoveCookie(string key)
		{
			Response.Cookies.Delete(key);
		}
	}
}
