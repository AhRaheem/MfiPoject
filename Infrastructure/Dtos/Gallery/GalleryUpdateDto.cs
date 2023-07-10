
namespace Infrastructure.Dtos.Gallery
{
	public class GalleryUpdateDto : IMapFrom<Core.Entites.Gallery>
	{
		[TranslateDisplay]
		public string? Id { get; set; }
		[TranslateDisplay("File")]
		public string? MainFileId { get; set; }
		[TranslateDisplay("Arabic Title")]
		public string? TitleAr { get; set; }
		[TranslateDisplay("English Title")]
		public string? TitleEn { get; set; }
		[TranslateDisplay("Published")]
		public bool IsPublished { get; set; }
		[TranslateDisplay]
		public IFormFile? File { get; set; }
	}
}
