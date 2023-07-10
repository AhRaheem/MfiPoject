


namespace Infrastructure.Dtos.Gallery
{
	public class GalleryItemDto : IMapFrom<GalleryItem>
	{
		[TranslateDisplay]
		public string? Id { get; set; }
		[TranslateDisplay("File")]
		public string? FileId { get; set; }
		
		[TranslateDisplay("Gallery")]
		public string? GalleryId { get; set; }
	}
}
