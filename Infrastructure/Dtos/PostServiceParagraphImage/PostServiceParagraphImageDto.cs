

namespace Infrastructure.Dtos.PostServiceParagraphImage
{
	public class PostServiceParagraphImageDto : IMapFrom<Core.Entites.PostServiceParagraphImage>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? FileId { get; set; }
        [TranslateDisplay]
        public string? PostServiceParagraphId { get; set; }
        [TranslateDisplay]
        public virtual PostServiceParagraphDto? PostServiceParagraph { get; set; }
    }
}
