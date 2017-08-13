using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WCF.Study.Learn.FaultService
{
    [ServiceContract]
    public interface IFaultService
    {
        int CauseExceptionByDivideZero(int x, int y);
    }

    [DataContract]
    public class FaultDetails
    {
        /// <summary>
        /// Error code
        /// </summary>
        [DataMember]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}
