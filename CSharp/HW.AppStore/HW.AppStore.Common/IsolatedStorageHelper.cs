using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.AppStore.Common
{
    public sealed class IsolatedStorageHelper
    {
        /// <summary>
        /// 加密保存到指定的路径下面，用";"分割
        /// </summary>
        public static void SaveDateTime()
        {
            SaveDateTime(DateTime.Now);
        }

        public static void SaveDateTime(DateTime fromDate)
        {
            string fromDateTime = fromDate.ToString("MM-dd-yyyy HH:mm:ss");
            string oldTime = "";
            if (!string.IsNullOrEmpty(oldTime))
            {
                fromDateTime = string.Format("{0};{1}", oldTime, fromDateTime);
            }

        }
    }
}
