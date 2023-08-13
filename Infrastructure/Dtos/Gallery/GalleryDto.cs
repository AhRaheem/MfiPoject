


namespace Infrastructure.Dtos.Gallery
{
	public class GalleryDto : IMapFrom<Core.Entites.Gallery>
	{
		[TranslateDisplay]
		public string? Id { get; set; }
		[TranslateDisplay("File")]
		public string? MainFileId { get; set; }
        [TranslateDisplay("FileExtention")]
        public string? FileExtention { get; set; }
		[TranslateDisplay("Arabic Name")]
		public string? TitleAr { get; set; }
        [TranslateDisplay("English Name")]
        public string? TitleEn { get; set; }
        [TranslateDisplay("Published")]
        public bool IsPublished { get; set; }
		public ICollection<GalleryItemDto>? Items { get; set; }
    }
}
