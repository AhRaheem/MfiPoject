
namespace Core.Entites
{
	public class Partner : BaseEntity
	{
		public string? PartnerCategoryId { get; set; }
		public virtual PartnerCategory? PartnerCategory { get; set; }

		public string? FileId { get; set; }

		public string? NameAr { get; set; }
		public string? NameEn { get; set; }
		public string? Website { get; set; }
	}
}
