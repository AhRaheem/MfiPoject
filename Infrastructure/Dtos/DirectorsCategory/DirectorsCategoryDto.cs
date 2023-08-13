

using Infrastructure.Dtos.Directors;

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
        [TranslateDisplay]
        public IFormFile? File { get; set; }
        public ICollection<DirectorsDto> Directors { get; set; }
    }
}
