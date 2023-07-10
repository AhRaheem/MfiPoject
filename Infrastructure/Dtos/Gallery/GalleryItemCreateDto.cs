


namespace Infrastructure.Dtos.Gallery
{
	public class GalleryItemCreateDto : IMapFrom<GalleryItem>
	{
		[TranslateDisplay]
		public IFormFile? File { get; set; }
		[TranslateDisplay("File")]
		public string? FileId { get; set; }
		[TranslateDisplay("Gallery")]
        public string? GalleryId { get; set; }
    }
}
