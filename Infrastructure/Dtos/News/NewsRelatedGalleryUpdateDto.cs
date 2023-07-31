using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.News
{
    public class NewsRelatedGalleryUpdateDto : IMapFrom<NewsRelatedGallery>
    {
        public string? Id { get; set; }
        public string? RelatedGalleryId { get; set; }
        public string? NewsId { get; set; }
    }
}
