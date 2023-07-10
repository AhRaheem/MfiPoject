using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.File
{
	public class FileDto : IMapFrom<Core.Entites.File>
    {
		[TranslateDisplay]
		public string? Id { get; set; }
		[TranslateDisplay]
		public string? Extention { get; set; }
		[TranslateDisplay]
		public string? Content { get; set; }
		[TranslateDisplay]
		public string? Name { get; set; }
	}
}
