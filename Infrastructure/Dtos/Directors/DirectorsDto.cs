

namespace Infrastructure.Dtos.Directors
{
	public class DirectorsDto : IMapFrom<Core.Entites.Directors>
	{
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? TitleAr { get; set; }
        [TranslateDisplay]
        public string? TitleEn { get; set; }
        [TranslateDisplay]
        public string? NameAr { get; set; }
        [TranslateDisplay]
        public string? NameEn { get; set; }
        [TranslateDisplay]
        public string? PositionNameAr { get; set; }
        [TranslateDisplay]
        public string? PositionNameEn { get; set; }
        [TranslateDisplay]
        public string? DirectorsCategoryId { get; set; }
        public virtual DirectorsCategory? DirectorsCategory { get; set; }
    }
}
