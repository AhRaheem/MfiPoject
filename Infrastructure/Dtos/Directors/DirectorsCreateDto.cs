﻿

namespace Infrastructure.Dtos.Directors
{
	public class DirectorsCreateDto : IMapFrom<Core.Entites.Directors>
	{
        [TranslateDisplay]
        public string? NameAr { get; set; }
        [TranslateDisplay]
        public string? NameEn { get; set; }
        [TranslateDisplay]
        public string? DirectorsCategoryId { get; set; }
    }
}
