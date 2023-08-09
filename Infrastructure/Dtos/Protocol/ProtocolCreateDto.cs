using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.Protocol
{
    public class ProtocolCreateDto : IMapFrom<Core.Entites.Protocol>
    {
        [TranslateDisplay]
        public PostState PostState { get; set; }
        [TranslateDisplay]
        public string? RejectReason { get; set; }
        [TranslateDisplay]
        public bool HomePost { get; set; }
        [TranslateDisplay]
        public bool Bannerpost { get; set; }
        [TranslateDisplay]
        public DateTime? BreakingFrom { get; set; }
        [TranslateDisplay]
        public DateTime? BreakingTo { get; set; }
        [TranslateDisplay]
        public bool Titled { get; set; }
        [TranslateDisplay]
        public string? MainFileId { get; set; }
        [TranslateDisplay]
        public string? TitleAr { get; set; }
        [TranslateDisplay]
        public string? TitleEn { get; set; }
        [TranslateDisplay]
        public string? IntroAr { get; set; }
        [TranslateDisplay]
        public string? IntroEn { get; set; }
        [TranslateDisplay]
        public IFormFile? File { get; set; }
    }
}
