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
        public virtual ICollection<Directors>? Directors { get; set; }
    }
}
