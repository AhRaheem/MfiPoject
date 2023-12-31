﻿

namespace Infrastructure.Dtos.Post
{
    public class PostAffiliateLawCreateDto : IMapFrom<PostAffiliateLaw>
    {
        [TranslateDisplay("Arabic Name")]
        public string? NameAr { get; set; }
        [TranslateDisplay("English Name")]
        public string? NameEn { get; set; }
        [TranslateDisplay("File")]
        public string? FileId { get; set; }
        [TranslateDisplay("FileExtention")]
        public string? FileExtention { get; set; }
        public string? PostId { get; set; }
        [TranslateDisplay]
        public IFormFile? File { get; set; }
    }
}
