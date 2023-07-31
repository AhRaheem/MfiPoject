using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.News
{
    public class NewsRelatedNewsCreateDto : IMapFrom<NewsRelatedNews>
    {
        public string? RelatedNewsId { get; set; }
        public string? NewsId { get; set; }
    }
}
