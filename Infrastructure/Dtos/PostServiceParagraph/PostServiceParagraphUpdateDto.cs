

namespace Infrastructure.Dtos.PostServiceParagraph
{
	public class PostServiceParagraphUpdateDto : IMapFrom<Core.Entites.PostServiceParagraph>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? TitleAr { get; set; }
        [TranslateDisplay]
        public string? TitleEn { get; set; }
        [TranslateDisplay]
        public string? ContentAr { get; set; }
        [TranslateDisplay]
        public string? ContentEn { get; set; }
        [TranslateDisplay]
        public string? PostId { get; set; }
    }
}
