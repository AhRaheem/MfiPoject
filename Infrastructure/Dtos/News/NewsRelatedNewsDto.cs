using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.News
{
    public class NewsRelatedNewsDto : IMapFrom<NewsRelatedNews>
    {
        public string? Id { get; set; }
        public string? RelatedNewsId { get; set; }
        public virtual Core.Entites.News? RelatedNews { get; set; }

        public string? NewsId { get; set; }
    }
}
