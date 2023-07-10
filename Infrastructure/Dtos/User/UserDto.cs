

namespace Infrastructure.Dtos.User
{
	public class UserDto : IMapFrom<ApplicationUser>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay("Name")]
        public string? UserName { get; set; }
        [TranslateDisplay]
        public string? Email { get; set; }
        [TranslateDisplay("Is Admin")]
        public bool IsAdmin { get; set; } = false;
        [TranslateDisplay("Is News Editor")]
        public bool IsNewsEditor { get; set; } = false;
        [TranslateDisplay("Is News Publisher")]
        public bool IsNewsPublisher { get; set; } = false;
        [TranslateDisplay("Is Gallery Editor")]
        public bool IsGalleryEditor { get; set; } = false;
        [TranslateDisplay("Is Gallery Publisher")]
        public bool IsGalleryPublisher { get; set; } = false;
    }
}
