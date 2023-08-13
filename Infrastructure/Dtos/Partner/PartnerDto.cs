

namespace Infrastructure.Dtos.Partner
{
	public class PartnerDto : IMapFrom<Core.Entites.Partner>
	{
		[TranslateDisplay]
		public string? Id { get; set; }
		[TranslateDisplay("Category")]
		public PartnerCategoryDto? PartnerCategory { get; set; }
		[TranslateDisplay("File")]
		public string? FileId { get; set; }
        [TranslateDisplay]
        public string? FileExtention { get; set; }
        [TranslateDisplay("Arabic Name")]
		public string? NameAr { get; set; }
        [TranslateDisplay("English Name")]
        public string? NameEn { get; set; }
		[TranslateDisplay]
		public string? Website { get; set; }
	}
}
