
namespace Core.Entites
{
	public class ApplicationUser : IdentityUser
	{
		public bool IsAdmin { get; set; } = false;
		public bool IsNewsEditor { get; set; } = false;
		public bool IsNewsPublisher { get; set; } = false;
		public bool IsGalleryEditor { get; set; } = false;
		public bool IsGalleryPublisher { get; set; } = false;
	}
}
