using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.NewsRelatedGallery
{
    public class NewsRelatedGalleryCreateDto : IMapFrom<Core.Entites.NewsRelatedGallery>
    {
        [TranslateDisplay]
        public string? RelatedGalleryId { get; set; }
        [TranslateDisplay]
        public string? NewsId { get; set; }
    }
}
