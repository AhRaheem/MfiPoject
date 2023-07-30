using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.AboutUs
{
    public class AboutUsDto
    {
        public string? Id { get; set; }
        public string? MainFileId { get; set; }
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }
        public string? IntroAr { get; set; }
        public string? IntroEn { get; set; }
        public string? BeneficiariesWordAr { get; set; }
        public string? BeneficiariesWordEn { get; set; }
        public string? VisionWordAr { get; set; }
        public string? VisionWordEn { get; set; }
        public string? VisionImageId { get; set; }
        public string? MissionWordAr { get; set; }
        public string? MissionWordEn { get; set; }
        public string? MissionImageId { get; set; }
    }
}
