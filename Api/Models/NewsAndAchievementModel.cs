using Core.Contracts.Mappings;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.NewsRelatedGallery;
using Infrastructure.Dtos.NewsRelatedNews;
using Infrastructure.Dtos.Post;
using Infrastructure.Dtos.PostArticleParagraph;
using Infrastructure.Dtos.Protocol;

namespace Api.Models
{
    public class NewsAndAchievementModel : IMapFrom<NewsDto>, IMapFrom<ProtocolDto>
    {
        public string? Id { get; set; }
        public string? MainFileId { get; set; }
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }

        public string? IntroAr { get; set; }
        public string? IntroEn { get; set; }
        public DateTime CreatedOn { get; set; }



        public virtual ICollection<PostArticleParagraphDto>? PostArticleParagraphs { get; set; }
        public virtual ICollection<PostAffiliateLawDto>? AffiliateLaws { get; set; }

        public virtual ICollection<NewsRelatedNewsDto>? NewsRelatedNews { get; set; }
        public virtual ICollection<NewsRelatedGalleryDto>? NewsRelatedGalleries { get; set; }
    }
}
