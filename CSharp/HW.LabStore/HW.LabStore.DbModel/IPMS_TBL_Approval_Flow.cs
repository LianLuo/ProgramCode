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
    
    public partial class IPMS_TBL_Approval_Flow
    {
        public int FlowId { get; set; }
        public Nullable<int> NextFlowId { get; set; }
        public string CurrentProcessRole { get; set; }
        public int ApprovalId { get; set; }
        public int StatusId { get; set; }
        public bool IsEProject { get; set; }
        public int RevisionNo { get; set; }
        public int VersionNo { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public string TransactionId { get; set; }
    }
}