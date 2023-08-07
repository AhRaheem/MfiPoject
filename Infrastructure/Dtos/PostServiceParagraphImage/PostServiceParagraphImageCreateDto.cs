

namespace Infrastructure.Dtos.PostServiceParagraphImage
{
	public class PostServiceParagraphImageCreateDto : IMapFrom<Core.Entites.PostServiceParagraphImage>
	{
        [TranslateDisplay]
        public string? FileId { get; set; }
        [TranslateDisplay]
        public string? PostServiceParagraphId { get; set; }
    }
}
