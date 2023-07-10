

namespace Infrastructure.Dtos.Post
{
	public class PostDto : IMapFrom<Core.Entites.Post>
	{
		[TranslateDisplay]
		public string? Id { get; set; }
        [TranslateDisplay("Type")]
        public virtual PostType PostType { get; set; }
		[TranslateDisplay("State")]
		public PostState PostState { get; set; }
		[TranslateDisplay("File")]
        public virtual string? MainFileId { get; set; }
        [TranslateDisplay("File")]
        public FileDto? MainFile { get; set; }
        [TranslateDisplay("Arabic Title")]
        public string? TitleAr { get; set; }
        [TranslateDisplay("English Title")]
        public string? TitleEn { get; set; }
        [TranslateDisplay("Breaking From")]
        public DateTime? BreakingFrom { get; set; }
        [TranslateDisplay("Breaking To")]
        public DateTime? BreakingTo { get; set; }
        [TranslateDisplay("Reject Reason")]
        public string? RejectReason { get; set; }
        public ICollection<PostParagraph>? Paragraphs { get; set; }
        public ICollection<PostAffiliateLaw>? AffiliateLaws { get; set; }
    }
}
