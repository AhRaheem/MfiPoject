using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public class Translator
    {
        private static IHttpContextAccessor? _httpContextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        //public Translator(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor= httpContextAccessor;
        //}


        public static Dictionary<string, Dictionary<string, string>>? LanguagesWords;

        public static List<string> MissedTranslateWords = new List<string>();

        public static void LoadLanguageFiles(string BasePath)
        {
            LanguagesWords = new Dictionary<string, Dictionary<string, string>>();
            foreach (var langFile in Directory.GetFiles(Path.Combine(BasePath, "Languages/")))
            {
                LoadLanguage(System.IO.File.ReadAllLines(langFile), new System.IO.DirectoryInfo(langFile).Name);
            }
        }

        static void LoadLanguage(string[] WordsLines, string LanguageName)
        {
            var words = new Dictionary<string, string>();
            foreach (var txt in WordsLines)
            {
                var txtArr = txt.Split(':');
                if (!words.ContainsKey(txtArr[0]))
                    words.Add(txtArr[0], txtArr[1]);
            }
            LanguagesWords!.Add(LanguageName, words);
        }

        public static string TranslateText(string Language, string Text)
        {
            if (string.IsNullOrWhiteSpace(Language))
                Language = (_httpContextAccessor?.HttpContext!.Request.Cookies["Lang"] ?? "En") + ".txt";

            try { return LanguagesWords![Language][Text]; }
            catch (Exception e)
            {
                if (!MissedTranslateWords.Contains(Text))
                    MissedTranslateWords.Add(Text);
                return Text;
            }
        }
    }
}
