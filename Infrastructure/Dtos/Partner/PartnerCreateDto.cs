

namespace Infrastructure.Dtos.Partner
{
	public class PartnerCreateDto : IMapFrom<Core.Entites.Partner>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay("Category")]
        public string? PartnerCategoryId { get; set; }
        public string? FileId { get; set; }
        [TranslateDisplay("Arabic Name")]
        public string? NameAr { get; set; }
        [TranslateDisplay("English Name")]
        public string? NameEn { get; set; }
        [TranslateDisplay]
        public string? Website { get; set; }
        [TranslateDisplay]
        public IFormFile? File { get; set; }
	}
}
