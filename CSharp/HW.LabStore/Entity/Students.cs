using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    public class Students:BaseEntity
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 学生学号
        /// </summary>
        public string UserNum { get; set; }

        /// <summary>
        /// 所在年级
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 所属专业
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        /// 所在课题组
        /// </summary>
        public string TopicGUID { get; set; }

        /// <summary>
        /// 所在实验室
        /// </summary>
        public string LabGUID { get; set; }

        /// <summary>
        /// 所在院系
        /// </summary>
        public string DepartGUID { get; set; }
    }
}
