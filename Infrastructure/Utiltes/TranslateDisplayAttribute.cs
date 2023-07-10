using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utiltes
{
	public class TranslateDisplayAttribute : DisplayNameAttribute
	{
		private string _key;

		public TranslateDisplayAttribute([CallerMemberName] string key = null)
		{
			_key = key;
		}

		public override string DisplayName => Helpers.Translator.TranslateText("", _key);
	}
}
