

namespace Infrastructure.Dtos.Achievement
{
	public class AchievementCreateDto : IMapFrom<Core.Entites.Achievement>
	{
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
        [TranslateDisplay]
        public IFormFile? File { get; set; }
    }
}
