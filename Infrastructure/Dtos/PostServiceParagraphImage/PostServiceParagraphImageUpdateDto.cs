

namespace Infrastructure.Dtos.PostServiceParagraphImage
{
	public class PostServiceParagraphImageUpdateDto : IMapFrom<Core.Entites.PostServiceParagraphImage>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? FileId { get; set; }
        [TranslateDisplay]
        public string? PostServiceParagraphId { get; set; }
    }
}
