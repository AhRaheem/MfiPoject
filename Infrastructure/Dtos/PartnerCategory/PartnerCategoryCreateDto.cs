

namespace Infrastructure.Dtos.PartnerCategory
{
	public class PartnerCategoryCreateDto : IMapFrom<Core.Entites.PartnerCategory>
	{
        [TranslateDisplay("Arabic Name")]
        public string? NameAr { get; set; }
        [TranslateDisplay("English Name")]
        public string? NameEn { get; set; }
    }
}
