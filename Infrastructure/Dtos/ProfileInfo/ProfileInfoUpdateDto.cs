using Core.Enums;


namespace Infrastructure.Dtos.ProfileInfo
{
	public class ProfileInfoUpdateDto : IMapFrom<Core.Entites.ProfileInfo>
	{
		[TranslateDisplay]
		public string? Id { get; set; }
		[TranslateDisplay]
		public string? Name { get; set; }
		[TranslateDisplay]
		public string? Value { get; set; }
		[TranslateDisplay]
		public ProfileInfoCategory Category { get; set; }
	}
}
