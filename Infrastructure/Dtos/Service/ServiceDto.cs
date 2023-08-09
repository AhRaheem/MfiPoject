using Infrastructure.Dtos.PostArticleParagraph;
using Infrastructure.Dtos.PostServiceParagraphImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.Service
{
    public class ServiceDto : IMapFrom<Core.Entites.Service>
    {
        public string? Id { get; set; }
        public DateTime? BreakingFrom { get; set; }
        public DateTime? BreakingTo { get; set; }
        public bool Titled { get; set; }
        public PostState PostState { get; set; }

        public string? RejectReason { get; set; }

        public bool HomePost { get; set; }
        public bool Bannerpost { get; set; }
        public string? MainFileId { get; set; }
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }

        public string? IntroAr { get; set; }
        public string? IntroEn { get; set; }

        public virtual ICollection<PostAffiliateLawDto>? AffiliateLaws { get; set; }
        public virtual ICollection<PostArticleParagraphDto>? PostArticleParagraphs { get; set; }
        public virtual ICollection<PostServiceParagraphImageDto>? PostServiceParagraphImages { get; set; }
    }
}
