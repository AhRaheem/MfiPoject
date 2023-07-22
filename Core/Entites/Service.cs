using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites.Base;

namespace Core.Entites
{
    public class Service : PostArticle
    {
        public virtual ICollection<PostServiceParagraphImage>? PostServiceParagraphImages { get; set; }
    }
}
