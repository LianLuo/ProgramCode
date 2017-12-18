using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string GUID { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public int CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public int ModifyTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
