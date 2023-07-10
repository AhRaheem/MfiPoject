

namespace Core.Entites
{
	public class PartnerCategory : BaseEntity
	{
		public string? NameAr { get; set; }
		public string? NameEn { get; set; }

		public virtual ICollection<Partner>? Partners { get; set; }
	}
}
