using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites.Base;

namespace Core.Entites
{
    public class News : PostArticle
    {
        public virtual ICollection<NewsRelatedNews>? NewsRelatedNews { get; set; }
        public virtual ICollection<NewsRelatedGallery>? NewsRelatedGalleries { get; set; }
    }
}
