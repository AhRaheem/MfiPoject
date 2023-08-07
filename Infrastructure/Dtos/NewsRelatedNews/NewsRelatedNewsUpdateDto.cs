using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.NewsRelatedNews
{
    public class NewsRelatedNewsUpdateDto : IMapFrom<Core.Entites.NewsRelatedNews>
    {
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? RelatedNewsId { get; set; }
        [TranslateDisplay]
        public string? NewsId { get; set; }
    }
}
