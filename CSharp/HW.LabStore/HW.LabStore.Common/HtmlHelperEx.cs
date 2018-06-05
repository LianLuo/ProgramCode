using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc
{
    public static class HtmlHelperEx
    {
        /// <summary>
        /// 16.00
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToString(this HtmlHelper helper, decimal number)
        {
            return string.Format("{0:N}", number);
        }

        public static IHtmlString NumberToStringRed(this HtmlHelper helper, decimal number)
        {
            if (number > 0)
            {
                return new HtmlString(string.Format("{0:N}", number));
            }
            return new HtmlString(("<span style='color:red;'>" + string.Format("{0:N}", number) + "</span>"));
        }
    }
}
