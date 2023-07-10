using Core.Enums;


namespace Infrastructure.Dtos.ProfileInfo
{
	public class ProfileInfoCreateDto : IMapFrom<Core.Entites.ProfileInfo>
	{
		[TranslateDisplay]
		public string? Name { get; set; }
		[TranslateDisplay]
		public string? Value { get; set; }
		[TranslateDisplay]
		public ProfileInfoCategory Category { get; set; }
	}
}
