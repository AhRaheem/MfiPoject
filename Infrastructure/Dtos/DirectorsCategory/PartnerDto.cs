

namespace Infrastructure.Dtos.DirectorsCategory
{
	public class DirectorsCategoryDto : IMapFrom<Core.Entites.DirectorsCategory>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? NameAr { get; set; }
        [TranslateDisplay]
        public string? NameEn { get; set; }
        [TranslateDisplay]
        public string? FileId { get; set; }
    }
}
