using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HW.LabStore.Entity
{
    public class UserModel
    {
        [DataMember]
        [DisplayName("ID")]
        public int ID { get; set; }
        [DataMember]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DataMember]
        [DisplayName("Gender")]
        public bool? Gender { get; set; }
        [DataMember]
        [DisplayName("User Age")]
        public int Age { get; set; }
        [DataMember]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DataMember]
        [DisplayName("User TelPhone")]
        public string Tel { get; set; }
        [DataMember]
        [DisplayName("lync")]
        public string QQ { get; set; }
        [DataMember]
        public string Birthday { get; set; }
        [DataMember]
        public string InTime { get; set; }
    }
}
