using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IWebHostEnvironment HostingEnvironment;
        public LanguageController(IWebHostEnvironment environment)
        {
            HostingEnvironment= environment;
        }

        public IActionResult Index(string Id)
        {
            var LangWords = System.IO.File.ReadAllLines(Path.Combine(HostingEnvironment.WebRootPath, $"Languages/{Id}.txt"));
            return View(LangWords.ToList());
        }

        public ActionResult SaveLanguageWords(string Id, Dictionary<string,string> TranslateWords)
        {
            using (StreamWriter file = new StreamWriter(Path.Combine(HostingEnvironment.WebRootPath, $"Languages/{Id}.txt")))
                foreach (var Wrd in TranslateWords)
                    file.WriteLine($"{Wrd.Key}:{Wrd.Value}");
            ReloadLanguageFiles();
            return RedirectToAction(nameof(Index), new { Id = Id });
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
