
namespace Core.Entites
{
	public class GalleryItem : BaseEntity
	{
		public string? FileId { get; set; }

        public string? GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery? Gallery { get; set; }
	}
}
