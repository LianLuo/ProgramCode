using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    /// <summary>
    /// 课题组[T_Topics]
    /// </summary>
    public class Topics:BaseEntity
    {
        /// <summary>
        /// 课题名称
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateGUID { get; set; }
    }
}
