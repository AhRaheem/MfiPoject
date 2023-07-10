

namespace Core.Entites
{
	public class Post : BaseEntity
	{
		public PostType PostType { get; set; }
		public PostState PostState { get; set; }
		public string? MainFileId { get; set; }
		public string? TitleAr { get; set; }
		public string? TitleEn { get; set; }
		public DateTime? BreakingFrom { get; set; }
		public DateTime? BreakingTo { get; set; }
		public string? RejectReason { get; set; }
		public virtual ICollection<PostParagraph>? Paragraphs { get; set; }
		public virtual ICollection<PostAffiliateLaw>? AffiliateLaws { get; set; }
	}
}
