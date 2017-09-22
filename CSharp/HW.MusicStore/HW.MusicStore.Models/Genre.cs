using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.MusicStore.Models
{
    public class Genre:BaseEntity
    {
        [DisplayName("流派名称")]
        public override string Name { get; set; }

        public virtual  string Description { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}
