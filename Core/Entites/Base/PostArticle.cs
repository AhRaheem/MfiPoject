using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites.Base
{
    public abstract class PostArticle : Post
    {
        public DateTime? BreakingFrom { get; set; }
        public DateTime? BreakingTo { get; set; }
        public bool Titled { get; set; }
        public virtual ICollection<PostArticleParagraph>? PostArticleParagraphs { get; set; }
    }
}
