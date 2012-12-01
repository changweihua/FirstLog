using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClogCommon
{
    /*************************************************************************************
    * CLR版本：         4.0.30319.269
    * 类 名 称：       Utils
    * 机器名称：       HSERVER
    * 命名空间：       FirstClogCommon
    * 文 件 名：       Utils
    * 创建时间：       2012/8/8 16:22:36
    * 作    者：       常伟华 Changweihua
    * 
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">需要截取的字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="defValue">长度不够，默认添加的值</param>
        /// <returns></returns>
        public static string GetSubString(string str, int length, string defValue)
        {
            int strLength = str.Length;
            StringBuilder sb = new StringBuilder(str);

            if (length >= strLength)
            {

                for (int i = 0; i < length - strLength; i++)
                {
                    sb.Append(defValue);
                }
            }

            return sb.ToString();
        }
    }
}
