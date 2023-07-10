

namespace Core.Entites
{
	public class ProfileInfo : BaseEntity
	{
		public string? Name { get; set; }
		public string? Value { get; set; }
		public ProfileInfoCategory Category { get; set; }
	}
}
