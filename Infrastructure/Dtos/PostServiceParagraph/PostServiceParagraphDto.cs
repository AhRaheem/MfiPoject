

using Infrastructure.Dtos.PostServiceParagraphImage;

namespace Infrastructure.Dtos.PostServiceParagraph
{
	public class PostServiceParagraphDto : IMapFrom<Core.Entites.PostServiceParagraph>
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
        [TranslateDisplay]
        public virtual ICollection<PostServiceParagraphImageDto>? PostServiceParagraphImages { get; set; }
    }
}
