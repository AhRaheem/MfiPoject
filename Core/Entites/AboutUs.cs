using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class AboutUs : Postbase
    {
        public string? BeneficiariesWordAr { get; set; }
        public string? BeneficiariesWordEn { get; set; }
        public string? VisionWordAr { get; set; }
        public string? VisionWordEn { get; set; }
        public string? VisionImageId { get; set; }
        public string? MissionWordAr { get; set; }
        public string? MissionWordEn { get; set; }
        public string? MissionImageId { get; set; }
        public string? CeoNameAr { get; set; }
        public string? CeoNameEn { get; set; }
        public string? ChairmanAr { get; set; }
        public string? ChairmanEn { get; set; }
        public virtual ICollection<Directors>? Directors { get; set; }
    }
}
