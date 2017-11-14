using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace HW.AppStore.Common
{
    public class SoftHelper
    {
        /// <summary>
        /// 获取设备号编号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber(string diskNum="d:")
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementClass(String.Format("win32_logicaldisk.deviceid=\"{0}\"",diskNum));
            disk.Get();

            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 获取CPU的序列号
        /// </summary>
        /// <returns></returns>
        public static string GetCPU()
        {
            string strCpu = string.Empty;

            ManagementClass mc = new ManagementClass("win32_Processor");
            ManagementObjectCollection cpuCollection = mc.GetInstances();

            foreach (ManagementObject ob in cpuCollection)
            {
                strCpu = ob.Properties["Processorid"].Value.ToString();
                break;
            }

            return strCpu;
        }

        /// <summary>
        /// 生成机器码
        /// </summary>
        /// <returns></returns>
        public static string GetMachineCode()
        {
            // 获取24位CPU和硬盘序列号
            string num = GetCPU() + GetDiskVolumeSerialNumber("C:");
            string machineCode = num.Substring(0, 24);
            return machineCode;
        }

        /// <summary>
        /// 存储密钥
        /// </summary>
        public static int[] intCode = new int[127];
        /// <summary>
        /// 存储机器码的ASCII值
        /// </summary>
        public static int[] intNumber = new int[25];
        /// <summary>
        /// 存储机器码字
        /// </summary>
        public static char[] charCode = new char[25];

        public static void SetIntCode()
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }
        }


        public static string GetRegistCode()
        {
            SetIntCode();
            charCode = GetMachineCode().ToCharArray();

            for (int i = 1; i < intNumber.Length; i++)
            {
                intNumber[i] = intCode[Convert.ToInt32(charCode[i])] + Convert.ToInt32(charCode[i]);
            }

            string asciiNum = string.Empty;

            for (int j = 1; j < intNumber.Length; j++)
            {
                if (intNumber[j] >= 48 && intNumber[j] <= 57) //判断字符ASCII值是否0－9之间
                {
                    asciiNum += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 65 && intNumber[j] <= 90) //判断字符ASCII值是否A－Z之间
                {
                    asciiNum += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 97 && intNumber[j] <= 122) //判断字符ASCII值是否a－z之间
                {
                    asciiNum += Convert.ToChar(intNumber[j]).ToString();
                }
                else //判断字符ASCII值不在以上范围内
                {
                    if (intNumber[j] > 122) //判断字符ASCII值是否大于z
                    {
                        asciiNum += Convert.ToChar(intNumber[j]).ToString();
                    }
                    else
                    {
                        asciiNum += Convert.ToChar(intNumber[j]).ToString();
                    }
                }
                
            }
            return asciiNum;
        }

        public void CheckRegist()
        {
            RegistryKey retKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("ll")
                .CreateSubKey("ll.INI");
            foreach (string reNumber in retKey.GetSubKeyNames())
            {
                if (reNumber == GetRegistCode())
                {
                    // 已经激活
                    return;
                }
            }

            Thread thread = new Thread(new ThreadStart(ThreadCheckRegist));
            thread.Start();
        }

        private static void ThreadCheckRegist()
        {
            // 首先有一个提示
            Int32 tLong;
            try
            {
                tLong = (Int32) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\angel", "UseTimes", 0);
                // 感谢您已经使用多少次
            }
            catch
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\angel", "UseTimes", 0,RegistryValueKind.DWord);
            }
            tLong = (Int32)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\angel", "UseTimes", 0);
            if (tLong < 30)
            {
                int times = tLong + 1;
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\angel", "UseTimes", times);
            }
            else
            {
                // 提示试用已经完了
                // 退出
            }
        }
    }
}
