using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class PostServiceParagraphImage : BaseEntity
    {
        public string? FileId { get; set; }
        public string? PostServiceParagraphId { get; set; }
        [ForeignKey("PostServiceParagraphId")]
        public virtual PostServiceParagraph? PostServiceParagraph { get; set; }
    }
}
