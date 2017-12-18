using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    /// <summary>
    /// 建筑物
    /// </summary>
    public class Buildings:BaseEntity
    {
        /// <summary>
        /// 建筑物名称
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// 建筑物编号
        /// </summary>
        public string BuildingNum { get; set; }

        /// <summary>
        /// 所在校区
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public string Position { get; set; }

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
