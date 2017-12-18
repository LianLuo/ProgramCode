using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    /// <summary>
    /// 药柜[T_StoreCab]
    /// </summary>
    public class StoreCab:BaseEntity
    {
        /// <summary>
        /// 药柜名称
        /// </summary>
        public string CabName { get; set; }

        /// <summary>
        /// 药柜编号
        /// </summary>
        public string CabNum { get; set; }

        /// <summary>
        /// 所在建筑物
        /// </summary>
        public string BuildingGUID { get; set; }

        /// <summary>
        /// 所在位置
        /// </summary>
        public string LabPosition { get; set; }

        /// <summary>
        /// 大体描述
        /// </summary>
        public string CabDescript { get; set; }

        /// <summary>
        /// 负责人名称
        /// </summary>
        public string Responsibility { get; set; }

        /// <summary>
        /// 负责人电话
        /// </summary>
        public string ResponsibilityTel { get; set; }
    }
}
