﻿

namespace Infrastructure.Dtos.PostArticleParagraph
{
	public class PostArticleParagraphUpdateDto : IMapFrom<Core.Entites.PostArticleParagraph>
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
        public string? FileId { get; set; }

        [TranslateDisplay]
        public IFormFile? File { get; set; }
    }
}
