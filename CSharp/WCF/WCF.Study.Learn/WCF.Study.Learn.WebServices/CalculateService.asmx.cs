using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WCF.Study.Learn.WebServices
{
    /// <summary>
    /// CalculateService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class CalculateService : System.Web.Services.WebService
    {
        [WebMethod]
        public float Calc(string num, string num2, string operate)
        {
            float first;
            float second;
            if (float.TryParse(num, out first) && float.TryParse(num2, out second))
            {
                switch (operate)
                {
                    case "+":
                        return first + second;
                    case "-":
                        return first - second;
                    case "*":
                        return first * second;
                    case "/":
                        if (second == 0)
                        {
                            return 0;
                        }
                        return first / second;
                    case "%":
                        return first % second;
                    default:
                        return float.MinValue;
                }
            }
            return float.MaxValue;
        }
    }
}
