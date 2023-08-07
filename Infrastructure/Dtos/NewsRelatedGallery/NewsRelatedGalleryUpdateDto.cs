using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.NewsRelatedGallery
{
    public class NewsRelatedGalleryUpdateDto : IMapFrom<Core.Entites.NewsRelatedGallery>
    {
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? RelatedGalleryId { get; set; }
        [TranslateDisplay]
        public string? NewsId { get; set; }
    }
}
