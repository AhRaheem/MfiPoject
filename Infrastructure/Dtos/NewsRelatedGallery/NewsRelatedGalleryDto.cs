using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.NewsRelatedGallery
{
    public class NewsRelatedGalleryDto : IMapFrom<Core.Entites.NewsRelatedGallery>
    {
        [TranslateDisplay]
        public string? Id { get; set; }
        [TranslateDisplay]
        public string? RelatedGalleryId { get; set; }
        [TranslateDisplay]
        public string? RelatedGalleryName { get; set; }
        [TranslateDisplay]
        public string? RelatedGalleryFileId { get; set; }
        [TranslateDisplay]
        public string? RelatedNewsFileExtention { get; set; }
        [TranslateDisplay]
        public string? NewsId { get; set; }
    }
}
