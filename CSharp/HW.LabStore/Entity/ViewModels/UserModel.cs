using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    public class UserModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Gender")]
        public bool? Gender { get; set; }
        [DisplayName("User Age")]
        public int Age { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("User TelPhone")]
        public string Tel { get; set; }
        [DisplayName("lync")]
        public string QQ { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime InTime { get; set; }
    }
}
