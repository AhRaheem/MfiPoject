

namespace Core.Entites
{
	public class PostParagraph : BaseEntity
	{
		public string? TitleAr { get; set; }
		public string? TitleEn { get; set; }
		public string? ContentAr { get; set; }
		public string? ContentEn { get; set; }

		public string? FileId { get; set; }

        public string? PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post? Post { get; set; }
	}
}
