using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       ArrayExtension
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       ArrayExtension
     * 创建时间:       2012/10/26 16:48:41
     * 作    者:       常伟华 Changweihua
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com
     * 
     * 修改时间:
     * 修 改 人:
     * 
     ************************************************************************************/
    /// <summary>
    /// Array 拓展类
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// 拓展方法，实现数组转成字符串
        /// </summary>
        /// <param name="array">需要转换的数组</param>
        /// <param name="separator">分隔符</param>
        /// <returns>字符串</returns>
        public static string Join(this Array array, string separator)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in array)
            {
                sb.Append(item + separator);
            }

            string result = sb.ToString().Substring(0, sb.ToString().Length - 1);

            return result;
        }
    }
}
