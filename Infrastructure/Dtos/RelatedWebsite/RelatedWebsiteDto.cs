

namespace Infrastructure.Dtos.RelatedWebsite
{
	public class RelatedWebsiteDto : IMapFrom<Core.Entites.RelatedWebsite>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? FileId { get; set; }
        [TranslateDisplay]
        public string? FileExtention { get; set; }
        [TranslateDisplay("Arabic Name")]
        public string? NameAr { get; set; }
        [TranslateDisplay("English Name")]
        public string? NameEn { get; set; }
        [TranslateDisplay("Link")]
        public string? Link { get; set; }
    }
}
