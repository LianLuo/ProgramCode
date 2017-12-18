using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    public class Teachers:BaseEntity
    {
        /// <summary>
        /// 教师名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 教师编号
        /// </summary>
        public string UserNum { get; set; }

        /// <summary>
        /// 所在办公室
        /// </summary>
        public string Office { get; set; }

        /// <summary>
        /// 办公室电话
        /// </summary>
        public string OfficeTel { get; set; }

        /// <summary>
        /// 所在课题组
        /// </summary>
        public string TopicGUID { get; set; }

        /// <summary>
        /// 所属实验室
        /// </summary>
        public string LabGUID { get; set; }

        /// <summary>
        /// 所属院系
        /// </summary>
        public string DepartGUID { get; set; }
    }
}
