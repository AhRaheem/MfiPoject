using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.News
{
    public class NewsRelatedGalleryDto : IMapFrom<NewsRelatedGallery>
    {
        public string? Id { get; set; }
        public string? RelatedGalleryId { get; set; }
        public virtual Core.Entites.Gallery? RelatedGallery { get; set; }

        public string? NewsId { get; set; }
    }
}
