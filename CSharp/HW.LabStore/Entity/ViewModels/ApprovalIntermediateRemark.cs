using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    public class ApprovalIntermediateRemark
    {
        /// <summary>
        /// Head of SDC,Head of LOB,Head of Finance
        /// </summary>
        public string FirstApprovingAuthority { get; set; }
        /// <summary>
        /// Head of SDC,Head of LOB,Head of Finance
        /// </summary>
        public string RevisedApprovingAuthority { get; set; }
        /// <summary>
        /// Head of SDC,Head of LOB,Head of Finance
        /// </summary>
        public string ProposedApprovingAuthority { get; set; }
        /// <summary>
        /// View UI
        /// Username:RemarkRevenue
        /// </summary>
        public string RemarkRevenue { get; set; }
        /// <summary>
        /// View UI
        /// Username:RemarkRevenue
        /// </summary>
        public string RemarkCost { get; set; }
        /// <summary>
        /// View UI
        /// Username:CommonRemark
        /// </summary>
        public string CommontRemark { get; set; }
    }
}
