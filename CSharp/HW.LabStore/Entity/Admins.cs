using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    /// <summary>
    /// 管理员表[T_Admins]
    /// </summary>
    public class Admins:BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 所属办公室
        /// </summary>
        public string Office { get; set; }

        /// <summary>
        /// 办公室电话
        /// </summary>
        public string OfficeTel { get; set; }
    }
}
