using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class NewsRelatedNews : BaseEntity
    {
        public string? RelatedNewsId { get; set; }
        [ForeignKey("RelatedNewsId")]
        public virtual News? RelatedNews { get; set; }

        public string? NewsId { get; set; }
        [ForeignKey("NewsId")]
        public virtual News? News { get; set; }
    }
}
