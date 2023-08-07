

using Infrastructure.Dtos.PostArticleParagraph;

namespace Infrastructure.Dtos.Achievement
{
	public class AchievementDto : IMapFrom<Core.Entites.Achievement>
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

        public virtual ICollection<PostAffiliateLawDto>? AffiliateLaws { get; set; }
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
    }
}
