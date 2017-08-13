using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCF.Study.Learn.FaultService
{
    public class FaultServiceImp:IFaultService
    {
        public int CauseExceptionByDivideZero(int x, int y)
        {
            int result = 0;
            try
            {
                result = x / y;
            }
            catch (Exception e)
            {
                FaultDetails fd = new FaultDetails
                {
                    ErrorCode = "E000001",
                    Message = e.Message
                };

                throw new FaultException<FaultDetails>(fd);
            }
            return result;
        }
    }
}
