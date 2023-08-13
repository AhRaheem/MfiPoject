using Infrastructure.Dtos.NewsRelatedGallery;
using Infrastructure.Dtos.NewsRelatedNews;
using Infrastructure.Dtos.PostArticleParagraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.News
{
    public class NewsDto : IMapFrom<Core.Entites.News>
    {
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? MainFileId { get; set; }
        [TranslateDisplay]
        public string? TitleAr { get; set; }
        [TranslateDisplay]
        public string? TitleEn { get; set; }
        [TranslateDisplay]
        public string? IntroAr { get; set; }
        [TranslateDisplay]
        public string? IntroEn { get; set; }
        [TranslateDisplay]
        public PostState PostState { get; set; }
        [TranslateDisplay]
        public string? RejectReason { get; set; }
        [TranslateDisplay]
        public bool HomePost { get; set; }
        [TranslateDisplay]
        public bool Bannerpost { get; set; }
        [TranslateDisplay]
        public DateTime? BreakingFrom { get; set; }
        [TranslateDisplay]
        public DateTime? BreakingTo { get; set; }
        [TranslateDisplay]
        public bool Titled { get; set; }

        public virtual ICollection<PostArticleParagraphDto>? PostArticleParagraphs { get; set; }
        public virtual ICollection<PostAffiliateLawDto>? AffiliateLaws { get; set; }

        public virtual ICollection<NewsRelatedNewsDto>? NewsRelatedNews { get; set; }
        public virtual ICollection<NewsRelatedGalleryDto>? NewsRelatedGalleries { get; set; }
        [TranslateDisplay]
        public DateTime CreatedOn { get; set; }
    }
}
