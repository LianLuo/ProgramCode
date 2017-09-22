using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.MusicStore.Models
{
    public class BaseEntity
    {
        [DisplayName("编号")]
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
    }
}
