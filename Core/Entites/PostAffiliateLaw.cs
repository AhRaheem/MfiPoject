

namespace Core.Entites
{
	public class PostAffiliateLaw : BaseEntity
	{
		public string? NameAr { get; set; }
		public string? NameEn { get; set; }
		public string? FileId { get; set; }

		public string? PostId { get; set; }
		[ForeignKey("PostId")]
		public virtual Post? Post { get; set; }
	}
}
