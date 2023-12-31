﻿

namespace Infrastructure.Dtos.RelatedWebsite
{
	public class RelatedWebsiteUpdateDto : IMapFrom<Core.Entites.RelatedWebsite>
	{
		[TranslateDisplay]
		public string? Id { get; set; }
		[TranslateDisplay]
		public string? FileId { get; set; }
		[TranslateDisplay("Arabic Name")]
		public string? NameAr { get; set; }
		[TranslateDisplay("English Name")]
		public string? NameEn { get; set; }
		[TranslateDisplay("Link")]
		public string? Link { get; set; }
        [TranslateDisplay]
        public IFormFile? File { get; set; }
	}
}
