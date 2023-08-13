using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Directors : BaseEntity
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? DirectorsCategoryId { get; set; }
        [ForeignKey("DirectorsCategoryId")]
        public virtual DirectorsCategory? DirectorsCategory { get; set; }
    }
}
