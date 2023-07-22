using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class NewsRelatedGallery : BaseEntity
    {
        public string? RelatedGalleryId { get; set; }
        [ForeignKey("RelatedGalleryId")]
        public virtual Gallery? RelatedGallery { get; set; }

        public string? NewsId { get; set; }
        //[ForeignKey("NewsId")]
        //public virtual News? News { get; set; }
    }
}
