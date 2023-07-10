

namespace Infrastructure.Dtos.RelatedWebsite
{
	public class RelatedWebsiteCreateDto : IMapFrom<Core.Entites.RelatedWebsite>
	{
		[TranslateDisplay]
		public string? FileId { get; set; }
		[TranslateDisplay("Arabic Name")]
		public string? NameAr { get; set; }
		[TranslateDisplay("English Name")]
		public string? NameEn { get; set; }
		[TranslateDisplay("Link")]
		public string? Link { get; set; }
		
		[AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [TranslateDisplay]
        public IFormFile? File { get; set; }
	}
}
