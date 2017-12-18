using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    public class Drugs:BaseEntity
    {
        /// <summary>
        /// 药物名称
        /// </summary>
        public string DrugName { get; set; }

        /// <summary>
        /// 药物编号
        /// </summary>
        public string DrugNum { get; set; }

        /// <summary>
        /// 药瓶编号
        /// </summary>
        public string DrugBottleNum { get; set; }

        /// <summary>
        /// 药瓶位置
        /// </summary>
        public string BottlePosition { get; set; }

        /// <summary>
        /// 放置位置
        /// </summary>
        public string PutGUID { get; set; }

        /// <summary>
        /// 使用指南
        /// </summary>
        public string UseGuide { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string Batch { get; set; }

        /// <summary>
        /// 事件编号
        /// </summary>
        public string EventNum { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 是否气体
        /// </summary>
        public bool IsGas { get; set; }

        /// <summary>
        /// 是否有毒
        /// </summary>
        public bool IsPoison { get; set; }

        /// <summary>
        /// 是否危险
        /// </summary>
        public bool IsDanger { get; set; }
    }
}
