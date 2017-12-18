using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    /// <summary>
    /// 实验室
    /// </summary>
    public class Labs:BaseEntity
    {
        /// <summary>
        /// 实验室名称
        /// </summary>
        public string LabName { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Responsibility { get; set; }

        /// <summary>
        /// 负责人电话
        /// </summary>
        public string ResponsibilityTel { get; set; }
    }
}
