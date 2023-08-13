

using Infrastructure.Dtos.DirectorsCategory;

namespace Infrastructure.Dtos.Directors
{
	public class DirectorsDto : IMapFrom<Core.Entites.Directors>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? NameAr { get; set; }
        [TranslateDisplay]
        public string? NameEn { get; set; }
        [TranslateDisplay]
        public string? DirectorsCategoryId { get; set; }
        public virtual DirectorsCategoryDto? DirectorsCategory { get; set; }
    }
}
