

namespace Core.Entites
{
	public class Gallery : BaseEntity
	{
		public virtual string? MainFileId { get; set; }
		public string? TitleAr { get; set; }
		public string? TitleEn { get; set; }
		public bool IsPublished { get; set; }
		public virtual ICollection<GalleryItem>? Items { get; set; }
	}
}
