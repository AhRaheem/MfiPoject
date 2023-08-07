using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.AboutUs
{
    public class AboutUsUpdateDto
    {
        [TranslateDisplay]
        public string? Id { get; set; }
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
        public string? BeneficiariesWordAr { get; set; }
        [TranslateDisplay]
        public string? BeneficiariesWordEn { get; set; }
        [TranslateDisplay]
        public string? VisionWordAr { get; set; }
        [TranslateDisplay]
        public string? VisionWordEn { get; set; }
        [TranslateDisplay]
        public string? VisionImageId { get; set; }
        [TranslateDisplay]
        public string? MissionWordAr { get; set; }
        [TranslateDisplay]
        public string? MissionWordEn { get; set; }
        [TranslateDisplay]
        public string? MissionImageId { get; set; }
    }
}
