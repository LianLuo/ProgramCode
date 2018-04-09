using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.LabStore.Entity
{
    public class ApprovalWorkflowModel
    {
        public ApprovalIntermediateResult IntermediateResult { get; set; }
        public ApprovalIntermediateRemark IntermediateRemark { get; set; }

        public bool HasData { get; set; }
        /// <summary>
        /// Only Proposed data or first submit not revised version
        /// </summary>
        public bool IsSingleData { get; set; }
        public int ProjectId { get; set; }
        public int ProjectBudgetId { get; set; }

        public ApprovalWorkflowModel()
        {
            IntermediateResult = new ApprovalIntermediateResult();
            IntermediateRemark = new ApprovalIntermediateRemark();
        }
    }
}
