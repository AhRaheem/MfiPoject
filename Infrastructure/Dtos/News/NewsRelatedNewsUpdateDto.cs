using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.News
{
    public class NewsRelatedNewsUpdateDto : IMapFrom<NewsRelatedNews>
    {
        public string? Id { get; set; }
        public string? RelatedNewsId { get; set; }
        public string? NewsId { get; set; }
    }
}
