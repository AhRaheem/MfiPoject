using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.NewsRelatedNews
{
    public class NewsRelatedNewsDto : IMapFrom<Core.Entites.NewsRelatedNews>
    {
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? RelatedNewsId { get; set; }
        [TranslateDisplay]
        public string? RelatedNewsName { get; set; }
        [TranslateDisplay]
        public string? RelatedNewsFileId { get; set; }
        [TranslateDisplay]
        public string? RelatedNewsFileExtention { get; set; }
        [TranslateDisplay]
        public string? NewsId { get; set; }
    }
}
