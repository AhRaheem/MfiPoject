

namespace Infrastructure.Dtos.PartnerCategory
{
	public class PartnerCategoryUpdateDto : IMapFrom<Core.Entites.PartnerCategory>
	{
		[TranslateDisplay]
		public string? Id { get; set; }
		[TranslateDisplay("Arabic Name")]
		public string? NameAr { get; set; }
		[TranslateDisplay("English Name")]
		public string? NameEn { get; set; }
	}
}
