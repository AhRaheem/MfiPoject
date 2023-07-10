using Core.Contracts.Mappings;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.Gallery
{
	public class GalleryCreateDto : IMapFrom<Core.Entites.Gallery>
	{
		[TranslateDisplay("Arabic Title")]
		public string? TitleAr { get; set; }
		[TranslateDisplay("English Title")]
		public string? TitleEn { get; set; }
		[TranslateDisplay("Published")]
		public bool IsPublished { get; set; }
		[TranslateDisplay]
		public IFormFile? File { get; set; }
	}
}
