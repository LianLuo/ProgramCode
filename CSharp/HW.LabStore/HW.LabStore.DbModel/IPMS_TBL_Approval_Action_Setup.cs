//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HW.LabStore.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class IPMS_TBL_Approval_Action_Setup
    {
        public int ActionId { get; set; }
        public string Description { get; set; }
        public int ConditionId { get; set; }
        public int PID { get; set; }
        public bool IsEnd { get; set; }
        public int Sequence { get; set; }
        public bool AutoApproval { get; set; }
        public string Message { get; set; }
        public bool ApprovalRequired { get; set; }
        public string MaxApproval { get; set; }
        public string CCEmail { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public string TransactionId { get; set; }
    
        public virtual IPMS_TBL_Approval_Condition_Setup IPMS_TBL_Approval_Condition_Setup { get; set; }
    }
}
