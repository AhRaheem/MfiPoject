using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.AboutUs
{
    public class AboutUsPageDto
    {
        public AboutUsUpdateDto? AboutUsDto { get; set; }
        public List<DirectorsCategory.DirectorsCategoryDto> DirectorsCategoryLstDto { get; set; }
    }
}
