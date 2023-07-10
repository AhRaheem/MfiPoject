

namespace Infrastructure.Dtos.Post
{
	public class PostCreateDto : IMapFrom<Core.Entites.Post>
	{
		public string Id { get; set; }
		[TranslateDisplay("Type")]
		public PostType PostType { get; set; }
		[TranslateDisplay("State")]
		public PostState PostState { get; set; } = PostState.New;
		[TranslateDisplay("File")]
		public string? MainFileId { get; set; }
		[TranslateDisplay("Arabic Title")]
		public string? TitleAr { get; set; }
		[TranslateDisplay("English Title")]
		public string? TitleEn { get; set; }
        [TranslateDisplay("Breaking From")]
        public DateTime? BreakingFrom { get; set; }
        [TranslateDisplay("Breaking To")]
        public DateTime? BreakingTo { get; set; }
        [TranslateDisplay]
		public IFormFile? File { get; set; }
	}
}
