

namespace Infrastructure.Dtos.Post
{
    public class PostAffiliateLawUpdateDto : IMapFrom<PostAffiliateLaw>
    {
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay("Arabic Name")]
        public string? NameAr { get; set; }
        [TranslateDisplay("English Name")]
        public string? NameEn { get; set; }
        [TranslateDisplay("File")]
        public string? FileId { get; set; }
        public string? PostId { get; set; }
        [TranslateDisplay]
        public IFormFile? File { get; set; }
    }
}
