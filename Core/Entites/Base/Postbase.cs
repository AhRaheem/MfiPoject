using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites.Base
{
    public abstract class Postbase : BaseEntity
    {
        public string? MainFileId { get; set; }
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }

        public string? IntroAr { get; set; }
        public string? IntroEn { get; set; }

        public virtual ICollection<PostAffiliateLaw>? AffiliateLaws { get; set; }

    }
}
