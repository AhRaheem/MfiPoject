

namespace Infrastructure.Dtos.Post
{
    public class PostParagraphUpdateDto : IMapFrom<PostParagraph>
    {
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay("Arabic Title")]
        public string? TitleAr { get; set; }
        [TranslateDisplay("English Title")]
        public string? TitleEn { get; set; }
        [TranslateDisplay("Arabic Content")]
        public string? ContentAr { get; set; }
        [TranslateDisplay("English Content")]
        public string? ContentEn { get; set; }
        [TranslateDisplay("File")]
        public string? FileId { get; set; }
        [TranslateDisplay]
        public IFormFile? File { get; set; }
        public string PostId { get; set; }
    }
}
