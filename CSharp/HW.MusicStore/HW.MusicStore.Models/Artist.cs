﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.MusicStore.Models
{
    public class Artist:BaseEntity
    {
        [DisplayName("艺术家名")]
        public virtual string Name { get; set; }
    }
}
